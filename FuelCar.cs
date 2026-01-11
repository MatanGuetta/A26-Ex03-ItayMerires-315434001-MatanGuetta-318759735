using Utils;
using UTILS = Utils.Utils;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car, IFuelable
    {
        private readonly FuelTank r_FuelTank;

        public FuelCar(string i_LicenseNumber, string i_Model)
            : base(i_LicenseNumber, i_Model, new FuelTank(UTILS.k_CarFuelType, UTILS.k_CarMaxFuelCapacity))
            {
            r_FuelTank = (FuelTank)r_EnergySource;
        }
        public void Refuel(float i_AmountToAdd, e_FuelType i_FuelType)
        {
            r_FuelTank.Refuel(i_AmountToAdd, i_FuelType);
            UpdateEnergyPercentage(r_FuelTank.CurrentAmount, r_FuelTank.MaxAmount);
        }
        public float CurrentFuelAmount
        {
            get { return r_FuelTank.CurrentAmount; }
            set
            {
                r_FuelTank.CurrentAmount = value;
                UpdateEnergyPercentage(r_FuelTank.CurrentAmount, r_FuelTank.MaxAmount);
            }
        }
        public e_FuelType FuelType
        {
            get { return r_FuelTank.FuelType; }
        }
        public float MaxFuelAmount
        {
            get { return r_FuelTank.MaxAmount; }
        }
    }
}
