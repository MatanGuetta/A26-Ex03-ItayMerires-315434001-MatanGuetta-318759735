using GarageManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace GarageManagementSystem
{
    public abstract class Car : Vehicle
    {
        private e_CarColor m_Color;
        private readonly int m_NumOfDoors; //2,3,4,5

    }
}
