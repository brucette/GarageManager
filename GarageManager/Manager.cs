﻿using GarageManager.Helpers;
using GarageManager.UserInterface;
using GarageManager.Vehicles.SubcClasses;
using GarageManager.Vehicles;
using System.Threading.Channels;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using GarageManager;
using System.Security.Principal;

namespace GarageManager
{
    internal class Manager
    {

        // should this be static?
        private ConsoleUI ui = new ConsoleUI();

        GarageHandler garagehandler = new GarageHandler();

        // ui.Get
        //Console.WriteLine($"Type: {type} Color:{color} Wheels:{numberOfWheels} Reg: {registrationNumber}"); 
        public void Start()
        {
            do
            {
                MenuHelpers.ShowMainMenu();
                string input = Console.ReadLine();

                //string input = ui.GetInput().ToUpper();

                switch (input)
                {
                    case MenuHelpers.Create:
                        MakeNewGarage(garagehandler);
                        break;
                    case MenuHelpers.Manage:
                        ManageExistingGarage(garagehandler);
                        break;
                    case MenuHelpers.Quit:
                        Environment.Exit(0);
                        break;
                    default:
                        //ui.Print("Not a valid selection!");
                        Console.WriteLine("Not a valid selection!");
                        break;
                }
            } while (true);
        }

        public static void MakeNewGarage(GarageHandler garagehandler)
        {
            //GarageHandler garagehandler = new GarageHandler();

            Console.WriteLine("Please enter the following details");
            string name = Util.AskForInput("Enter a name for your garage: ");
            uint capacity = Util.AskForNumber("How many spots should the garage have?: ");
            string popluate = Util.AskForInput("Would you like to populate the garage with some vehicles? (y/n): ");

            Garage<IVehicle> garage;

            switch (popluate.ToLower())
            {
                case "y":
                    List<IVehicle> vehiclesToPopulate = GenerateVehicles();
                     garage = garagehandler.CreateGarage(name, capacity, vehiclesToPopulate);
                    break;
                case "n":
                    garage = garagehandler.CreateGarage(name, capacity);
                    break;
                default:
                    break;
            }
        }

        // If user is to enter vehicles
        public static List<IVehicle> GenerateVehicles()
        {
            uint numberOfVehicles = Util.AskForNumber("How many vehicles?: ");
            List<IVehicle> vehiclesToAdd = new List<IVehicle>();

            for (int i = 0; i < numberOfVehicles; i++)
            {
                Console.WriteLine($"Select type for vehicle {i + 1}:");
                MenuHelpers.GetVehicleType();
                string type = Console.ReadLine();

                string color = Util.AskForInput("Color: ");
                uint numberOfWheels = Util.AskForNumber("Number of wheels: ");

                IVehicle newVehicle = VehicleFactory.MakeVehicle(type, color, numberOfWheels);

                vehiclesToAdd.Add(newVehicle);

            }
            return vehiclesToAdd;
        }

        // **** If vehicles are to be automatically populated ****


        public static void ManageExistingGarage(GarageHandler garagehandler)
        {
            Console.WriteLine("Enter the name of the garage you want to manage: ");

            garagehandler.DisplayExistingGarages();
            string garageName = Console.ReadLine();

            Console.WriteLine($"{garageName} it is!");

            MenuHelpers.ShowOperationMenu();
            string operation = Console.ReadLine();

            Console.WriteLine($"{operation} it is!");

            switch (operation)
            {
                case MenuHelpers.Park:
                    //garagehandler.garageDirectory[garageName];
                    break;
                case MenuHelpers.Get:
                    break;
                case MenuHelpers.View:
                    break;
                case MenuHelpers.Search:
                    break;
                default:
                    break;
            }
        }
    }
}