using System;

namespace GarageManagementSystem
{
	public class Wheel
	{
        String m_Manufacturer;
        float m_CurrentAirPressure;
        float m_MaxAirPressure;

        public Wheel(String i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        void Inflate(float i_AirPressureToAdd)
        {

        }
    }
}
