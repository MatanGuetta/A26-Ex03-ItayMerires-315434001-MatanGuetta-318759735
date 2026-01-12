using Utils;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, VehicleGarageData> r_Vehicles;

        public GarageManager()
        {
            r_Vehicles = new Dictionary<string, VehicleGarageData>();
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return r_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public void AddNewVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            if (IsVehicleInGarage(i_Vehicle.LicenseNumber))
            {
                ChangeVehicleStatus(i_Vehicle.LicenseNumber, e_ServiceStatus.InRepair);

                throw new ArgumentException(string.Format(
                    "Vehicle with license number {0} is already in the garage. Its status has been updated to 'In Repair'.",
                    i_Vehicle.LicenseNumber));
            }
            else
            {
                VehicleGarageData newVehicleData = new VehicleGarageData(i_OwnerName, i_OwnerPhone, i_Vehicle);
                r_Vehicles.Add(i_Vehicle.LicenseNumber, newVehicleData);
            }
        }

        public void LoadVehiclesFromFile(string i_FilePath)
        {
            if (!File.Exists(i_FilePath))
            {
                throw new FileNotFoundException("The vehicle database file was not found.", i_FilePath);
            }

            string[] allLinesInFile = File.ReadAllLines(i_FilePath);

            foreach (string line in allLinesInFile)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                try
                {
                    string[] data = line.Split(Utils.Utils.k_FileSplitChar);

                    string vehicleType = data[0].Trim();
                    string licensePlate = data[1].Trim();
                    string modelName = data[2].Trim();
                    float energyPercent = float.Parse(data[3].Trim());
                    string tireManufacturer = data[4].Trim();
                    float currentAirPressure = float.Parse(data[5].Trim());
                    string ownerName = data[6].Trim();
                    string ownerPhoneNumber = data[7].Trim();

                    Vehicle newVehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);

                    if (newVehicle != null)
                    {
                        if (newVehicle is IFuelable fuelVehicle)
                        {
                            fuelVehicle.CurrentFuelAmount = (energyPercent / 100f) * fuelVehicle.MaxFuelAmount;
                        }
                        else if (newVehicle is IChargeable electricVehicle)
                        {
                            electricVehicle.BatteryTimeRemaining = (energyPercent / 100f) * electricVehicle.MaxBatteryTime;
                        }
                        newVehicle.InstallWheels(tireManufacturer, currentAirPressure);
                        applySpecificPropertiesByVehicleType(newVehicle, data);
                        this.AddNewVehicle(newVehicle, ownerName, ownerPhoneNumber);
                    }
                }

                catch (Exception)
                {
                    continue;
                }

            }
        }

        private void applySpecificPropertiesByVehicleType(Vehicle i_Vehicle, string[] i_Data)
        {
            if (i_Vehicle is Car car)
            {
                car.Color = (e_CarColor)Enum.Parse(typeof(e_CarColor), i_Data[8].Trim());
                car.NumOfDoors = (e_NumOfDoors)int.Parse(i_Data[9].Trim());
            }
            else if (i_Vehicle is Motorcycle motorcycle)
            {
                motorcycle.LicenseType = (e_LicenseType)Enum.Parse(typeof(e_LicenseType), i_Data[8].Trim());
                motorcycle.EngineVolume = int.Parse(i_Data[9].Trim());
            }
            else if (i_Vehicle is Truck truck)
            {
                truck.IsCarryingHazardousMaterials = bool.Parse(i_Data[8].Trim());
                truck.CargoVolume = float.Parse(i_Data[9].Trim());
            }
        }

        private VehicleGarageData getVehicleGarageDataOrThrow(string i_LicenseNumber)
        {
            if (!r_Vehicles.TryGetValue(i_LicenseNumber, out VehicleGarageData? o_vehicleGarageData) || o_vehicleGarageData == null)
            {
                throw new ArgumentException(string.Format("vehicle with license number {0} was not found.", i_LicenseNumber));
            }

            return o_vehicleGarageData;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, e_ServiceStatus i_NewStatus)
        {
            VehicleGarageData vehicleData;

            vehicleData = getVehicleGarageDataOrThrow(i_LicenseNumber);
            vehicleData.ServiceStatus = i_NewStatus;
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            VehicleGarageData vehicleData;

            vehicleData = getVehicleGarageDataOrThrow(i_LicenseNumber);
            vehicleData.Vehicle.InflateAllWheelsToMax();
        }

        public void RefuelVehicle(string i_LicenseNumber, e_FuelType i_FuelType, float i_AmountToAdd)
        {
            VehicleGarageData vehicleData;

            vehicleData = getVehicleGarageDataOrThrow(i_LicenseNumber);
            if (vehicleData.Vehicle is IFuelable fuelVehicle)
            {
                handleIncorrectFuelType(fuelVehicle.FuelType, i_FuelType);
                fuelVehicle.Refuel(i_AmountToAdd, i_FuelType);
            }
            else
            {
                throw new ArgumentException("This vehicle cannot be refueled.");
            }
        }

        private void handleIncorrectFuelType(e_FuelType i_FuelTypeIWant, e_FuelType i_FuelTypeIGet)
        {
            if (i_FuelTypeIWant != i_FuelTypeIGet)
            {
                throw new ArgumentException(string.Format("Incorrect fuel type. Vehicle requires {0}, but received {1}.", i_FuelTypeIWant, i_FuelTypeIGet));
            }
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_MinutesToCharge)
        {
            VehicleGarageData vehicleData;

            vehicleData = getVehicleGarageDataOrThrow(i_LicenseNumber);
            if (vehicleData.Vehicle is IChargeable electricVehicle)
            {
                chargeVehicleHelper(electricVehicle, i_MinutesToCharge);
            }
            else
            {
                throw new ArgumentException("This vehicle cannot be charged.");
            }
        }

        private void chargeVehicleHelper(IChargeable i_ElectricVehicle, float i_MinutesToCharge)
        {
            float hoursToCharge = i_MinutesToCharge / 60f;
            i_ElectricVehicle.Charge(hoursToCharge);
        }

        public string GetVehicleDetails(string i_LicenseNumber)
        {
            VehicleGarageData vehicleData;

            vehicleData = getVehicleGarageDataOrThrow(i_LicenseNumber);
            return string.Format("License Number: {0}{5}Owner Name: {1}{5}Owner Phone: {2}{5}Garage Status: {3}{5}{4}",
                   i_LicenseNumber,
                   vehicleData.OwnerName,
                   vehicleData.OwnerPhoneNumber,
                   vehicleData.ServiceStatus,
                   vehicleData.Vehicle.ToString(),
                   Environment.NewLine
            );
        }

        public List<string> GetAllLicenseNumbers(e_ServiceStatus? i_FilterStatus= null)
        {
            List<string> licenseNumbers = new List<string>();

            foreach (KeyValuePair<string, VehicleGarageData> vehicle in r_Vehicles)
            {
                if (i_FilterStatus == null || vehicle.Value.ServiceStatus == i_FilterStatus)
                {
                    licenseNumbers.Add(vehicle.Key);
                }
            }

            return licenseNumbers;
        }
    }
}
