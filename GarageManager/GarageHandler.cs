﻿using GarageManager.Vehicles.BaseClass;
using GarageManager.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageManager.Helpers;

namespace GarageManager
{
    public class GarageHandler : IHandler
    {
        public Dictionary<string, Garage<IVehicle>> garageDirectory = new Dictionary<string, Garage<IVehicle>>();

        public void DisplayExistingGarages()
        {
            StringBuilder garages = new StringBuilder();    
            garages.Append("[");

            foreach (var item in garageDirectory)
            { 
                garages.Append($"Name: {item.Key}, ");
            }

            //if (garageDirectory.Count > 0)
            //{
            //    // Remove the trailing comma
            //    garages.Length--; // Removes the last character (comma)
            //}
            garages.Append("]");

            Util.PrintWithColour($"Current garages in the system: {garages.ToString()}", ConsoleColor.Cyan);
        }

        public Garage<IVehicle> CreateGarage(string name, uint capacity)
        {
            Garage<IVehicle> newGarage = new Garage<IVehicle>(name, capacity);
            garageDirectory.Add(newGarage.Name, newGarage);
            return newGarage;
        }
        
        public Garage<IVehicle> CreateGarage(string name, uint capacity, List<IVehicle> toBePopulated)
        {
            Garage<IVehicle> newGarage = new Garage<IVehicle>(name, capacity, toBePopulated);
            garageDirectory.Add(newGarage.Name, newGarage);
            return newGarage;
        }

        // Park a vehicle
        public void Park(Garage<IVehicle> garage, Func<IVehicle> vehicle)
        {
            if (garage.isFull)
            {
                Console.WriteLine("Sorry, the garage is full!");
            }
            else
            {
                IVehicle newVehicle = vehicle();
                garage.AddVehicle(newVehicle);
            }
        }

        // Get a vehicle
        public void GetVehicle(Garage<IVehicle> garage, IVehicle vehicle)
        {
            garage.RemoveVehicle(vehicle, vehicle.RegistrationNumber);
        }

        // DisplayAllVehicles and their properties
        public void DisplayAllVehicles(Garage<IVehicle> garage)
        {
            foreach (IVehicle vehicle in garage)
            {
                if (vehicle != null)
                    Console.WriteLine(vehicle.ToString());
                //Console.WriteLine($"Type: {vehicle.GetType().Name}");
            }
        }

        // Search the garage for vehicles
        public void SearchGarage(Garage<IVehicle> garage)
        {
            Dictionary<string, string> validSearchTerms = new();
            validSearchTerms.Add("colour", "");
            validSearchTerms.Add("numberOfWheels", "");
            validSearchTerms.Add("typeOfVehicle", "");


            MenuHelpers.ShowSearchInstructions();
            IEnumerable<string> searchTerms = Util.GetSearchTerms();

            bool isValid = Util.IsValid(searchTerms, validSearchTerms);
           
            
            // IEnumerable<Vehicle>
            
        }
    }
}
