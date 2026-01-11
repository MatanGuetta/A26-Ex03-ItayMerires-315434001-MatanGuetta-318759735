
namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicenseNumber;
        protected float m_CurrentEnergyPercentage { get; set; }
        private readonly List<Wheel> r_Wheels;
        protected readonly EnergySource r_EnergySource;

        public Vehicle(string i_Model, string i_LicenseNumber, EnergySource i_EnergySource)
        {
            r_Model = i_Model;
            r_LicenseNumber = i_LicenseNumber;
            r_EnergySource = i_EnergySource;
            UpdateEnergyPercentage(r_EnergySource.CurrentAmount, r_EnergySource.MaxAmount);
            r_Wheels = new List<Wheel>(this.NumOfWheels);
        }
        public void InstallWheels(string i_Manufacturer, float i_CurrentAirPressure)
        {
            for (int i = 0; i < this.NumOfWheels; i++)
            {
                Wheel newWheel = new Wheel(i_Manufacturer, 0, this.MaxAirPressure);
                newWheel.Inflate(i_CurrentAirPressure);
                r_Wheels.Add(newWheel);
            }
        }
        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in r_Wheels)
            {
            wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }
        protected void UpdateEnergyPercentage(float i_CurrentEnergyLevel, float i_MaxEnergyLevel)
        {
            m_CurrentEnergyPercentage = (i_CurrentEnergyLevel / i_MaxEnergyLevel) * 100f;
        }
        public string Model
        {
            get { return r_Model; }
        }
        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }
        public List<Wheel> Wheels
        {
            get { return r_Wheels; }
        }
        protected abstract int NumOfWheels { get; }
        protected abstract float MaxAirPressure { get; }
        public override string ToString()
        {
            System.Text.StringBuilder vehicleDataString= new System.Text.StringBuilder();

            vehicleDataString.AppendLine("License Number: " + r_LicenseNumber);
            vehicleDataString.AppendLine("Model Name: " + r_Model);
            vehicleDataString.AppendLine("Energy Percentage: " + m_CurrentEnergyPercentage.ToString("0.0") + "%");
            vehicleDataString.AppendLine(r_EnergySource.ToString());
            vehicleDataString.AppendLine("Wheels Information:");
            foreach (Wheel wheel in r_Wheels)
            {
                vehicleDataString.AppendLine(wheel.ToString());
            }

            return vehicleDataString.ToString();
        }
    }
    
}
