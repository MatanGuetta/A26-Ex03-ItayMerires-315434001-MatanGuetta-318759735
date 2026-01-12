using Utils;
//using UTILS = Utils.Utils;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private e_CarColor m_Color;
        private e_NumOfDoors m_NumOfDoors;

        public Car(string i_LicenseNumber, string i_Model, EnergySource i_EnergySource)
            : base(i_LicenseNumber, i_Model, i_EnergySource) { }

        protected override int NumOfWheels
        {
            get { return k_CarNumOfWheels; }
        }

        protected override float MaxAirPressure
        {
            get { return k_CarMaxAirPressure; }
        }

        public e_CarColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public e_NumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }

        public override string ToString()
        {
            string carString;

            carString = string.Format("{0}Car Color: {1}{3}Number of Doors: {2}{3}",
            base.ToString(),
            m_Color,
            m_NumOfDoors,
            Environment.NewLine);

            return carString;
        }

    }
}
