using System;
using Utils;

namespace GarageManagementSystem
{
	public class FuelTruck : Truck, IFuelable
    {
		private e_FuelType m_FuelType { get; set; }
        private float m_CurrentFuelAmount { get; set; }
        private float m_MaxFuelAmount { get; set; }

        void IFuelable.Refuel(e_FuelType i_FuelType, float i_AmountToRefuel)
        {
            // Implementation for refueling the Truck
        }
    }
}
