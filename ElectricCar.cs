using Utils;
using UTILS = Utils.Utils;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car, IChargeable
    {
        private readonly Battery r_Battery;

        public ElectricCar(string i_LicenseNumber, string i_Model)
            : base(i_LicenseNumber, i_Model, new Battery(UTILS.k_CarMaxBatteryTime))
        {
            r_Battery = (Battery)r_EnergySource; 
        }

        public void Charge(float i_HoursToAdd)
        {
            r_Battery.Charge(i_HoursToAdd);
            UpdateEnergyPercentage(r_Battery.CurrentAmount, r_Battery.MaxAmount);
        }

        public float BatteryTimeRemaining
        {
            get { return r_Battery.CurrentAmount; }
            set
            {
                r_Battery.CurrentAmount = value;
                UpdateEnergyPercentage(r_Battery.CurrentAmount, r_Battery.MaxAmount);
            }
        }

        public float MaxBatteryTime
        {
            get { return r_Battery.MaxAmount; }
        }
    }
}
