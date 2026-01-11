using UTILS = Utils.Utils;

namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private bool m_IsCarryingHazardousMaterials;
        private float m_CargoVolume;

        public Truck(string i_LicenseNumber, string i_Model, EnergySource i_EnergySource)
            :base(i_LicenseNumber, i_Model, i_EnergySource) { }

        protected override int NumOfWheels
        {
            get { return UTILS.k_TruckNumOfWheels; }
        }
        protected override float MaxAirPressure
        {
            get { return UTILS.k_TruckMaxAirPressure; }
        }
        public bool IsCarryingHazardousMaterials
        {
            get { return m_IsCarryingHazardousMaterials; }
            set { m_IsCarryingHazardousMaterials = value; }
        }
        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }
        public override string ToString()
        {
            string truckString;

            truckString=string.Format("{0}Hazardous Materials: {1}{3}Cargo Volume: {2}{3}",
                        base.ToString(),
                        m_IsCarryingHazardousMaterials ? "Yes" : "No",
                        m_CargoVolume,
                        Environment.NewLine);

            return truckString;
        }
    }
}
