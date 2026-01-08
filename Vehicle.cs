using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace GarageManagementSystem
{
    public abstract class Vehicle
    {
        private readonly string m_Model;
        private readonly string m_LicenseNumber;
        private float m_CurrentEnergyPrecentage;
        private List<Wheel> m_Wheels;

        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private e_ServiceStatus m_ServiceStatus = e_ServiceStatus.InRepair;

        public Vehicle(string i_Model, string i_LicenseNumber,
            float i_CurrentEnergyPrecentage, List<Wheel> i_Wheels)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_CurrentEnergyPrecentage = i_CurrentEnergyPrecentage;
            m_Wheels = i_Wheels;
        }

        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
            wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }
    }

}
