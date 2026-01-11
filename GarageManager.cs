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
            VehicleGarageData newVehicle = new VehicleGarageData(i_OwnerName, i_OwnerPhone, i_Vehicle);
            r_Vehicles.Add(i_Vehicle.LicenseNumber, newVehicle);
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
