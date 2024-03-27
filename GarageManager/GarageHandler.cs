using GarageManager.Vehicles.BaseClass;
using GarageManager.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageManager.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace GarageManager
{
    public class GarageHandler : IHandler
    {
        //public Dictionary<string, Garage<IVehicle>> garageDirectory = new Dictionary<string, Garage<IVehicle>>();

        public Garage<IVehicle> CreateGarage(uint capacity)
        {
            return new Garage<IVehicle>(capacity);
        }
        
        public Garage<IVehicle> CreateGarage(uint capacity, List<IVehicle> toBePopulated)
        {
            return new Garage<IVehicle>(capacity, toBePopulated);
        }

        // Park a vehicle
        public void Park(Garage<IVehicle> garage, Func<IVehicle> vehicle)
        {
                IVehicle newVehicle = vehicle();
                garage.AddVehicle(newVehicle);
        }

        // Get a vehicle
        public void GetVehicle(Garage<IVehicle> garage, string registration)
        {
            garage.RemoveVehicle(registration);
        }

        // DisplayAllVehicles and their properties
        public void DisplayAllVehicles(Garage<IVehicle> garage)
        {
            foreach (IVehicle vehicle in garage)
            {
                if (vehicle != null)
                    Console.WriteLine(vehicle.ToString());
            }
        }

        public string CheckRegistrationNumber(Garage<IVehicle> garage)
        {
            string regNum = "";

            while (regNum.Length != 6)
            {
                regNum = Util.AskForInput("Registration number: ");
                if (regNum.Length != 6)
                {
                    Util.PrintWithColour("Registration number must be exactly 6 characters long, in the format \"ABC123\"", ConsoleColor.DarkRed);
                }
            }

            while (true)
            {
                string firstHalf = regNum.Substring(0, 3).ToUpper();
                string secondHalf = regNum.Substring(3);

                bool firstHalfCorrect = char.IsLetter(firstHalf[0]) && char.IsLetter(firstHalf[1]) && char.IsLetter(firstHalf[2]);
                bool secondHalfCorrect = char.IsDigit(secondHalf[0]) && char.IsDigit(secondHalf[1]) && char.IsDigit(secondHalf[2]);
                bool correctFormat = firstHalfCorrect && secondHalfCorrect;

                if (!correctFormat)
                {
                    Util.PrintWithColour($"Check your registration number, the format is incorrect", ConsoleColor.DarkRed);
                }
                else
                {
                    bool found = garage.SearchByRegistration(regNum);
                    if (!found)
                    {
                        return regNum;
                    }
                    else
                    {
                        Util.PrintWithColour($"There is already a vehicle with that registration number parked in our garage.", ConsoleColor.DarkRed);

                    }
                }

                regNum = Util.AskForInput("Registration number: ");
            }
        }

        // Search the garage for vehicles
        public void SearchGarage(Garage<IVehicle> garage)
        {
            List<string> validSearchTerms = new List<string>() { "colour", "numberOfWheels", "typeOfVehicle" };

            Dictionary<string, string> searchTerms = new();

            MenuHelpers.ShowSearchInstructions();
            string input = Util.AskForInput("Enter properties to search: ");

            string[] pairs = input.Split(',');

            foreach (string pair in pairs) 
            {
                string property = pair.Substring(0, pair.IndexOf(':'));

                if (validSearchTerms.Contains(property))
                {
                    string searchFor = pair.Substring(pair.IndexOf(':'));

                    // remove colon
                    searchFor = searchFor.Substring(1);

                    searchTerms.Add(property, searchFor);
                }
            }
          
            garage.FilterVehicles(searchTerms);
        }
    }
}
