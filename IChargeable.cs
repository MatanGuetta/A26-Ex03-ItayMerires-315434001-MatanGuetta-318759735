namespace Ex03.GarageLogic
{
    public interface IChargeable
    {
        void Charge(float i_HoursToAdd);
        float BatteryTimeRemaining { get; }
        float MaxBatteryTime { get; }
    }
}