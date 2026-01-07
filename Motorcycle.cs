using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace GarageManagementSystem
{
    public abstract class Motorcycle : Vehicle
    {
        private e_LicenseType m_LicenseType;
        private int m_EngineVolume;
    }
}
