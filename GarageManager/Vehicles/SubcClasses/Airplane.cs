using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageManager.Vehicles.BaseClass;

namespace GarageManager.Vehicles.SubcClasses
{
    internal class Airplane : Vehicle
    {
        public uint NumberOfEngines { get; }

        public Airplane(string registrationNumber, string colour, uint numberOfWheels, uint numberOfEngines)
            : base(registrationNumber, colour, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }
    }
}
