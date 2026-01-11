using Utils;

namespace Ex03.GarageLogic
{
    public class VehicleGarageData
    {
        private string r_OwnerName;
        private string r_OwnerPhoneNumber;
        private e_ServiceStatus m_ServiceStatus;
        private Vehicle m_Vehicle;

        public VehicleGarageData(string i_OwnerName,string  i_OwnerPhoneNumber,Vehicle i_Vehicle)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_Vehicle = i_Vehicle;
            m_ServiceStatus = e_ServiceStatus.InRepair;
        }

        public string OwnerPhoneNumber
        {
            get { return r_OwnerPhoneNumber; }
        }
        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }
        public string OwnerName
        {
            get { return r_OwnerName; }
        }
        public e_ServiceStatus ServiceStatus
        {
            get { return m_ServiceStatus; }
            set { m_ServiceStatus = value; }
        }

    }
}
