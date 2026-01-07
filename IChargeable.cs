using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementSystem
{
    interface IChargeable
    {
        float m_BatteryTimeRemaining { get; set; }
        float m_MaxBatteryTime { get; }

        void Charge(float i_HoursToCharge)
        {

        }
    }
}