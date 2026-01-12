using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {
        private readonly GarageManager r_GarageManager;

        public ConsoleUI()
        {
            r_GarageManager = new GarageManager();
        }

        private void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                printMenu();
                try
                {
                    e_UserChoices choice = getEnumChoice<e_UserChoices>("Please select an option: ");
                    isRunning = handleUserChoice(choice);
                }
                catch (Exception ex)
                {
                    System.System.Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void printMenu()
        {
            System.System.Console.WriteLine("\n======= Garage Management System =======");
            System.System.Console.WriteLine("1. Load vehicles from database file");
            System.System.Console.WriteLine("2. Add a new vehicle to the garage");
            System.System.Console.WriteLine("3. Show all license numbers (with filter)");
            System.System.Console.WriteLine("4. Change a vehicle's status");
            System.System.Console.WriteLine("5. Inflate a vehicle's wheels to maximum");
            System.System.Console.WriteLine("6. Refuel a fuel-powered vehicle");
            System.System.Console.WriteLine("7. Charge an electric vehicle");
            System.System.Console.WriteLine("8. Show full vehicle details");
            System.System.Console.WriteLine("9. Exit");
        }

        private bool handleUserChoice(e_UserChoices i_Choice)
        {
            switch (i_Choice)
            {
                case e_UserChoices.addNewVehicle:
                    addNewVehicleInteraction();
                    break;
                case e_UserChoices.ShowLicenseNumbers:
                    //showLicenseNumbersInteraction();
                    break;
                case e_UserChoices.changeVehicleStatus:
                    //changeStatusInteraction();
                    break;
                case e_UserChoices.inflateWheelsToMax:
                    //inflateToMaxInteraction();
                    break;
                case e_UserChoices.refuelVehicle:
                    //refuelInteraction();
                    break;
                case e_UserChoices.chargeVehicle:
                    //chargeInteraction();
                    break;
                case e_UserChoices.showFullVehicleDetails:
                    //showDetailsInteraction();
                    break;
                case e_UserChoices.Exit:
                    return false;
            }
            return true;
        }

        private void addNewVehicleInteraction()
        {
            System.Console.Write("Enter License Number: ");
            string license = System.Console.ReadLine();

            if (r_GarageManager.IsVehicleInGarage(license))
            {
                updateExistingVehicleStatus(license);
            }
            else
            {
                createNewVehicleProcess(license);
            }
        }

        private void updateExistingVehicleStatus(string i_LicenseNumber)
        {
            r_GarageManager.ChangeVehicleStatus(i_LicenseNumber, e_ServiceStatus.InRepair);
            System.Console.WriteLine("Vehicle with license number {0} is already in the garage. Status changed to 'In Repair'.", i_LicenseNumber);
        }

        private void createNewVehicleProcess(string i_LicenseNumber)
        {
            try
            {
                string typeChoice = getVehicleTypeFromUser();
                string modelName = getModelNameFromUser();

                Vehicle newVehicle = VehicleCreator.CreateVehicle(typeChoice, i_LicenseNumber, modelName);

                setupWheels(newVehicle);
                setupSpecificVehicleData(newVehicle);
                registerOwnerAndAddVehicle(newVehicle);
            }
            catch (FormatException)
            {
                System.Console.WriteLine("Error: Invalid input format. Please enter numbers where required.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }

        private string getVehicleTypeFromUser()
        {
            System.Console.WriteLine("Select Vehicle Type:");
            foreach (string type in VehicleCreator.SupportedTypes)
            {
                System.Console.WriteLine("- " + type);
            }
            return System.Console.ReadLine();
        }

        private string getModelNameFromUser()
        {
            System.Console.Write("Enter Model Name: ");
            return System.Console.ReadLine();
        }

        private void setupWheels(Vehicle i_Vehicle)
        {
            System.Console.Write("Enter Wheel Manufacturer: ");
            string wheelMaker = System.Console.ReadLine();

            System.Console.Write("Enter Current Tire Pressure: ");
            if (!float.TryParse(System.Console.ReadLine(), out float currentPressure))
            {
                throw new FormatException("Invalid tire pressure.");
            }

            i_Vehicle.InstallWheels(wheelMaker, currentPressure);
        }

        private void setupSpecificVehicleData(Vehicle i_Vehicle)
        {
            if (i_Vehicle is Car car)
            {
                setupCarProperties(car);
            }
            else if (i_Vehicle is Motorcycle motorcycle)
            {
                setupMotorcycleProperties(motorcycle);
            }
            else if (i_Vehicle is Truck truck)
            {
                setupTruckProperties(truck);
            }
        }

        private void setupCarProperties(Car i_Car)
        {
            i_Car.Color = getEnumChoice<e_CarColor>("Enter Car Color (Blue, Green, White, Black): \n");
            i_Car.NumOfDoors = getEnumChoice<e_NumOfDoors>("Enter Number of Doors (two, three, four, five): \n");
        }

        private void setupMotorcycleProperties(Motorcycle i_Motorcycle)
        {
            i_Motorcycle.LicenseType = getEnumChoice<e_LicenseType>("Enter License Type (A1, A2, AA, B): \n");

            System.Console.Write("Enter Engine Volume: ");
            if (!int.TryParse(System.Console.ReadLine(), out int volume))
            {
                throw new FormatException("Invalid engine volume.");
            }
            i_Motorcycle.EngineVolume = volume;
        }

        private void setupTruckProperties(Truck i_Truck)
        {
            System.Console.Write("Is carrying hazardous materials? (True/False): ");
            if (!bool.TryParse(System.Console.ReadLine(), out bool isHazardous))
            {
                throw new FormatException("Invalid boolean value.");
            }
            i_Truck.IsCarryingHazardousMaterials = isHazardous;

            System.Console.Write("Enter Cargo Volume: ");
            if (!float.TryParse(System.Console.ReadLine(), out float volume))
            {
                throw new FormatException("Invalid cargo volume.");
            }
            i_Truck.CargoVolume = volume;
        }

        private void registerOwnerAndAddVehicle(Vehicle i_Vehicle)
        {
            System.Console.Write("Enter Owner Name: ");
            string ownerName = System.Console.ReadLine();

            System.Console.Write("Enter Owner Phone: ");
            string ownerPhone = System.Console.ReadLine();

            r_GarageManager.AddNewVehicle(i_Vehicle, ownerName, ownerPhone);
            System.Console.WriteLine("Vehicle added successfully.");
        }

        private T getEnumChoice<T>(string i_Message) where T : struct
        {
            System.System.Console.Write(i_Message);
            if (!Enum.TryParse(System.Console.ReadLine(), out T result) || !Enum.IsDefined(typeof(T), result))
            {
                throw new FormatException("Invalid choice. Please try again.");
            }
            return result;
        }
    }
}
