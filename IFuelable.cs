using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace GarageManagementSystem
{
    interface IFuelable
    {
        e_FuelType m_FuelType { get; }
        float m_CurrentFuelAmount { get; set; }
        float m_MaxFuelAmount { get; }
        void Refuel(e_FuelType i_FuelType, float i_AmountToRefuel);
    }
}

