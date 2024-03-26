using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Helpers
{
    public class MenuHelpers
    {
        public const string Create = "1";
        public const string Manage = "2";
        public const string Quit = "0";
        
        public const string Park = "1";
        public const string Get = "2";
        public const string View = "3";
        public const string Search = "4";

        public const string Airplane = "1";
        public const string Boat = "2";
        public const string Bus = "3";
        public const string Car = "4";
        public const string Motorcycle = "5";

        public const string Colour = "1";
        public const string NumberOfWheels = "2";
        public const string TypeOfVehicle = "3";
        //public const string Registration = "4";

        public static void ShowMainMenu()
        {
            Console.WriteLine(
                 $"\n{Create}. Create a new garage" +
                 $"\n{Manage}. Manage an existing garage" +
                 $"\n{Quit}. Quit program");
        }

        //public static void GetInfoForNewGarage()
        //{
        //    Console.WriteLine("Please enter the following details");
        //}

        public static void ManageExistingGarage()
        { 
            string name = Util.AskForInput("Enter the name of the garage: ");
        }

        public static void ShowOperationMenu()
        {
            Console.WriteLine(
                $"\n{Park}. Park a vehicle" +
                $"\n{Get}. Get a vehicle" +
                $"\n{View}. View vehicles" +
                $"\n{Search}. Search for vehicles" +
                $"\n{Quit}. Quit program");
        }
        
        public static void GetVehicleType()
        {
            Console.WriteLine(
                $"\n{Airplane}. Airplane" +
                $"\n{Boat}. Boat" +
                $"\n{Bus}. Bus" +
                $"\n{Car}. Car" +
                $"\n{Motorcycle}. Motorcycle" +
                $"\n{Quit}. Quit program");
        }

        public static void ShowSearchInstructions()
        {
            Console.WriteLine("\nYou may search for any combination of the following properties:");
            //Console.WriteLine(
                //$"\n{Colour}. Colour" +
                //$"\n{NumberOfWheels}. Number of wheels" +
                //$"\n{TypeOfVehicle}. Type of vehicle" +
                //$"\n{Quit}. Quit program"
                //);
                
            Util.PrintWithColour("[colour, numberOfWheels, typeOfVehicle]", ConsoleColor.Cyan);

            Console.WriteLine("Enter the properties you want to search followed by a colon and the term you want to look for\n. Separate each search item by a comma.\n ");
            Util.PrintWithColour("E.g. colour:blue, numberOfWheels:4", ConsoleColor.Cyan);
        }
    }
}  
 