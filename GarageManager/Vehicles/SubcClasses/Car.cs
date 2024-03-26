using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageManager.Vehicles.BaseClass;

namespace GarageManager.Vehicles.SubcClasses
{
    internal class Car : Vehicle
    {
        public string Fueltype { get; }

        public Car(string registrationNumber, string colour, uint numberOfWheels, string fueltype)
            : base(registrationNumber, colour, numberOfWheels)
        {
            Fueltype = fueltype;
        }

        public override string ToString()
        {
            string baseProperties = base.ToString();
            return baseProperties + $"Fuel type: {Fueltype}\n";
        }
    }
}
