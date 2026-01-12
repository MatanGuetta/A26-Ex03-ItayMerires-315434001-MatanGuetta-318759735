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

        public void Run()
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
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void printMenu()
        {
            Console.WriteLine("\n======= Garage Management System =======");
            Console.WriteLine("1. Load vehicles from database file");
            Console.WriteLine("2. Add a new vehicle to the garage");
            Console.WriteLine("3. Show all license numbers (with filter)");
            Console.WriteLine("4. Change a vehicle's status");
            Console.WriteLine("5. Inflate a vehicle's wheels to maximum");
            Console.WriteLine("6. Refuel a fuel-powered vehicle");
            Console.WriteLine("7. Charge an electric vehicle");
            Console.WriteLine("8. Show full vehicle details");
            Console.WriteLine("9. Exit");
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
            string license = Console.ReadLine();

            if (r_GarageManager.IsVehicleInGarage(license))
            {
                r_GarageManager.AddNewVehicle(null, null, null);
            }
            else
            {
                Console.WriteLine("Select Vehicle Type: ");
                foreach (string type in VehicleCreator.SupportedTypes)
                {
                    Console.WriteLine("- " + type);
                }
                string typeChoice = Console.ReadLine();

                System.Console.Write("Enter Model Name: ");
                string model = Console.ReadLine();

                Vehicle newVehicle = VehicleCreator.CreateVehicle(typeChoice, license, model);

                System.Console.Write("Enter Owner Name: ");
                string name = Console.ReadLine();
                System.Console.Write("Enter Owner Phone: ");
                string phone = Console.ReadLine();

                r_GarageManager.AddNewVehicle(newVehicle, name, phone);
                Console.WriteLine("Vehicle added successfully.");
            }
        }

        // Additional interaction methods (showDetails, refuel, etc.) follow the same try-catch pattern.

        private T getEnumChoice<T>(string i_Message) where T : struct
        {
            System.Console.Write(i_Message);
            if (!Enum.TryParse(Console.ReadLine(), out T result) || !Enum.IsDefined(typeof(T), result))
            {
                throw new FormatException("Invalid choice. Please try again.");
            }
            return result;
        }
    }
}
