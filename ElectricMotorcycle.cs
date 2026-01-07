using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementSystem
{
    public class ElectricMotorcycle : Motorcycle, IChargeable
    {
        public float m_BatteryTimeRemaining { get; set; }
        public float m_MaxBatteryTime { get; }

        void IChargeable.Charge(float i_HoursToCharge)
        {
            // Implementation for charging the electric motorcycle
        }
    }
}
