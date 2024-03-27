using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GarageManager.Vehicles.BaseClass
{
    public class Vehicle : IVehicle
    {
        private string registrationNumber;

        public string RegistrationNumber { get; set; }
        public string Colour { get; set; }
        public uint NumberOfWheels { get; set; }

        public Vehicle(string registrationNumber, string colour, uint numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Colour = colour;
            NumberOfWheels = numberOfWheels;
            //MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return $"Type: {GetType().Name} Colour: {Colour} Number of wheels: {NumberOfWheels} Registration number: {RegistrationNumber} ";
        }
    }
}
