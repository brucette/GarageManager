using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Vehicles.BaseClass
{
    public class Vehicle : IVehicle
    {
        private string registrationNumber;
        //private int maxSpeed;


        public string RegistrationNumber { get; set; }
        public string Colour { get; set; }
        public uint NumberOfWheels { get; set; }
        //public int MaxSpeed { get; set; }

        public Vehicle(string registrationNumber, string colour, uint numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Colour = colour;
            NumberOfWheels = numberOfWheels;
            //MaxSpeed = maxSpeed;
        }
    }
}
