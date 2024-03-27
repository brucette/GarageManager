using GarageManager.Vehicles;
using GarageManager.Vehicles.BaseClass;
using GarageManager.Vehicles.SubcClasses;
using System;
using System.Security.Cryptography.X509Certificates;

namespace GarageManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Garage Manager");

                var manager = new Manager();
                manager.Start();
        }
    }
}
