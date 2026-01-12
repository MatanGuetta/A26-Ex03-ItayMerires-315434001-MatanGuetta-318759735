using Utils;
using UTILS = Utils.Utils;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private e_LicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_LicenseNumber, string i_Model, EnergySource i_EnergySource)
            : base(i_LicenseNumber, i_Model, i_EnergySource) { }

        protected override int NumOfWheels
        {
            get { return UTILS.k_MotorcycleNumOfWheels; }
        }

        protected override float MaxAirPressure
        {
            get { return UTILS.k_MotorcycleMaxAirPressure; } 
        }

        public e_LicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        public override string ToString()
        {
            string motorcycleString;

            motorcycleString = string.Format("{0}License Type: {1}{3}Engine Volume: {2} cc{3}",
                               base.ToString(),
                               m_LicenseType,
                               m_EngineVolume,
                               Environment.NewLine);

            return motorcycleString;
        }

    }
}
