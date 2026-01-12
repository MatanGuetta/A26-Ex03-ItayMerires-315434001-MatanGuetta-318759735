using Ex03.GarageLogic;

namespace Utils
{
    public static class Utils
    {
        public static void ThrowIfOutOfRange(float i_CurrentValue, float i_MaxValue, float i_AmountToAdd)
        {
            float maxPossibleToAdd;

            if (i_CurrentValue + i_AmountToAdd > i_MaxValue)
            {
                maxPossibleToAdd = i_MaxValue - i_CurrentValue;
                throw new ValueRangeException(0, maxPossibleToAdd);
            }
        }

        public const int k_MotorcycleNumOfWheels = 2;
        public const float k_MotorcycleMaxAirPressure = 29f;
        public const e_FuelType k_MotorcycleFuelType = e_FuelType.Octan98;
        public const float k_MotorcycleMaxFuelCapacity = 6.8f;
        public const float k_MotorcycleMaxBatteryTime = 2.6f;

        public const int k_CarNumOfWheels = 5;
        public const float k_CarMaxAirPressure = 33f;
        public const e_FuelType k_CarFuelType = e_FuelType.Octan95;
        public const float k_CarMaxFuelCapacity = 47f;
        public const float k_CarMaxBatteryTime = 4.2f;

        public const int k_TruckNumOfWheels = 12; 
        public const float k_TruckMaxAirPressure = 26f;
        public const e_FuelType k_TruckFuelType = e_FuelType.Soler;
        public const float k_TruckMaxFuelCapacity = 140f;

        public const char k_FileSplitChar = ',';
    }

    public enum e_ServiceStatus
    {
        InRepair,
        Repaired,
        Paid
    }

    public enum e_LicenseType
    {
        A1,
        A2,
        AA,
        B
    }

    public enum e_CarColor
    {
        Blue,
        Green,
        White,
        Black
    }

    public enum e_FuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }
    public enum e_NumOfDoors
    {
        two=2,
        three=3,
        four=4,
        five=5
    }
    public enum e_UserChoices
    {
        addNewVehicle=1,
        ShowLicenseNumbers=2,
        changeVehicleStatus=3,
        inflateWheelsToMax=4,
        refuelVehicle=5,
        chargeVehicle=6,
        showFullVehicleDetails=7,
        Exit=9
    }
}
