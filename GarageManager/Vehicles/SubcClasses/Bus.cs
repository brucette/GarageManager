using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageManager.Vehicles.BaseClass;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GarageManager.Vehicles.SubcClasses
{
    internal class Bus : Vehicle
    {
        public uint NumberOfSeats { get; }

        public Bus(string registrationNumber, string colour, uint numberOfWheels, uint numberOfSeats)
            : base(registrationNumber, colour, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}
