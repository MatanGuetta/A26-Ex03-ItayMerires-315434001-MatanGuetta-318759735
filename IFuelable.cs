using Utils;

namespace Ex03.GarageLogic
{
    public interface IFuelable
    {
        void Refuel(float i_AmountToAdd, e_FuelType i_FuelType);
        e_FuelType FuelType { get; }
        float CurrentFuelAmount { get; }
        float MaxFuelAmount {  get; }
    }
}
