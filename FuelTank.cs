using Utils;

namespace Ex03.GarageLogic
{
    public class FuelTank : EnergySource
    {
        private readonly e_FuelType r_FuelType;

        public FuelTank(e_FuelType i_FuelType, float i_MaxFuelTankCapacity) :
            base(i_MaxFuelTankCapacity)
        {
            r_FuelType = i_FuelType;
        }
        public e_FuelType FuelType
        {
            get { return r_FuelType; }
        }
        public void Refuel(float i_AmountToAdd, e_FuelType i_FuelType)
        {
            handleIncorrectFuelType(i_FuelType);
            Fill(i_AmountToAdd);
        }
        private void handleIncorrectFuelType(e_FuelType i_FuelType)
        {
            if (r_FuelType != i_FuelType)
            {
                throw new ArgumentException(string.Format("Fuel Type {0} does not match the vehicle's fuel type ({1}).", i_FuelType, r_FuelType));
            }
        }
        public override string ToString()
        {
            return string.Format("Fuel Type: {0}{2}Current Fuel Amount: {1} Liters",
                          r_FuelType,
                          m_CurrentAmount,
                          Environment.NewLine);
        }
    }
}
