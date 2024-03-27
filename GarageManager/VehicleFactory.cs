using GarageManager.Helpers;
using GarageManager.Vehicles;
using GarageManager.Vehicles.SubcClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager
{
    public static class VehicleFactory
    {
        public static IVehicle MakeVehicle(string type, string regNum, string color, uint wheels)
        {
            IVehicle newVehicle;

            switch (type)
            {
                case MenuHelpers.Airplane:
                    uint numberOfEngines = Util.AskForNumber("Number of Engines for Airplane: ");
                    newVehicle = new Airplane(regNum, color, wheels, numberOfEngines);
                    break;
                case MenuHelpers.Boat:
                    uint length = Util.AskForNumber("Length of Boat: ");
                    newVehicle = new Boat(regNum, color, wheels, length);
                    break;
                case MenuHelpers.Bus:
                    uint numberOfSeats = Util.AskForNumber("Number of seats on the Bus: ");
                    newVehicle = new Bus(regNum, color, wheels, numberOfSeats);
                    break;
                case MenuHelpers.Car:
                    string fueltype = Util.AskForInput("Fuel type of car: ");
                    newVehicle = new Car(regNum, color, wheels, fueltype);
                    break;
                case MenuHelpers.Motorcycle:
                    uint cylinderVolume = Util.AskForNumber("Cylinder volume for motorcycle: ");
                    newVehicle = new Motorcycle(regNum, color, wheels, cylinderVolume);
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type.");
            }
            
            return newVehicle;  
        }
    }
}
