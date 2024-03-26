using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageManager.Vehicles.BaseClass;

namespace GarageManager.Vehicles.SubcClasses
{
    internal class Boat : Vehicle
    {
        public uint Length { get; }

        public Boat(string registrationNumber, string colour, uint numberOfWheels, uint length)
            : base(registrationNumber, colour, numberOfWheels)
        {
            Length = length;
        }
    }
}
