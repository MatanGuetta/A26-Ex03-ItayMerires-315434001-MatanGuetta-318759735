using UTILS = Utils.Utils;

namespace Ex03.GarageLogic
{
	public class Wheel
	{
        private readonly String r_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public Wheel(String i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }
        public void Inflate(float i_AirPressureToAdd)
        {
            handlePressureOutOfRange(i_AirPressureToAdd);
            m_CurrentAirPressure += i_AirPressureToAdd;
        }
        private void handlePressureOutOfRange(float i_AirPressureToAdd)
        {
            UTILS.ThrowIfOutOfRange(m_CurrentAirPressure, r_MaxAirPressure, i_AirPressureToAdd);
        }
        public string Manufacturer
        {
            get { return r_Manufacturer; }
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }
        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }
        public override string ToString()
        {
            return string.Format("Manufacturer: {0}, Pressure: {1}/{2}", r_Manufacturer, m_CurrentAirPressure,r_MaxAirPressure);
        }
    }
}
