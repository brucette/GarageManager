using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageManager.Vehicles.BaseClass;

namespace GarageManager.Vehicles.SubcClasses
{
    internal class Motorcycle : Vehicle
    {
        public uint CylinderVolume { get; }

        public Motorcycle(string registrationNumber, string colour, uint numberOfWheels, uint cylinderVolume)
            : base(registrationNumber, colour, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }
    }
}
