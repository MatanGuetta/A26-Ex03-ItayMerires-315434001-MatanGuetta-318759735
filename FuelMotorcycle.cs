using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace GarageManagementSystem
{
    public class FuelMotorcycle : Motorcycle, IFuelable
    {
        public e_FuelType m_FuelType { get; set; }
        public float m_CurrentFuelAmount { get; set; }
        public float m_MaxFuelAmount { get; set; }

        void IFuelable.Refuel(e_FuelType i_FuelType, float i_AmountToRefuel)
        {
            // Implementation for refueling the motorcycle
        }

    }
}
