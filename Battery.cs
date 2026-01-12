
namespace Ex03.GarageLogic
{
    public class Battery : EnergySource 
    {
        public Battery(float i_MaxbatteryTime)
            : base(i_MaxbatteryTime) { }

        public void Charge(float i_HoursToAdd)
        {
            Fill(i_HoursToAdd);
        }

        public override string ToString()
        {
            return string.Format("Battery Time Remaining: {0} Hours{2}Max Battery Time: {1} Hours",
                                  m_CurrentAmount,
                                  r_MaxAmount,
                                  Environment.NewLine);
        }

    }
}
