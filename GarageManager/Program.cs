﻿using GarageManager.Vehicles;
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
            //GarageHandler garageHandler = new GarageHandler();
            //Garage<IVehicle> mygarage = garageHandler.CreateGarage("mygarage", 20);
            //IVehicle myCar = new Car("ABC123", "Red", 4, 200, "Gasoline");

            //while (true)
            //{
            //    Console.WriteLine($"Initial capacity:           {mygarage.Length}\n" +
            //                      $"Amount of available spots:  {mygarage.availableSpots.Count}\n" +
            //                      $"Is Full:                    {mygarage.isFull}");

            //    Console.WriteLine("\n1. Park a vehicle\n2. Get a vehicle");
            //    string selection = Console.ReadLine();

            //    switch (selection)
            //    {
            //        case "1":
            //            garageHandler.Park(mygarage, myCar);
            //            break;
            //        case "2":
            //            // ask for registration number
            //            garageHandler.GetVehicle(mygarage, myCar);
            //            break;
            //        default:
            //            Console.WriteLine("Wrong entry");
            //            break;
            //    }

            //    //mygarage.ShowVehicleDetails();

            //    Console.WriteLine($"Initial capacity: {mygarage.Length}\n" +
            //                      $"Available spots:  {mygarage.availableSpots.Count}\n" +
            //                      $"Is Full:          {mygarage.isFull}");


            Console.WriteLine("Hello!");

                var manager = new Manager();
                manager.Start();
        
        }
    }
}
