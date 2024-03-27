using GarageManager.Helpers;
using GarageManager.UserInterface;
using GarageManager.Vehicles.SubcClasses;
using GarageManager.Vehicles;
using System;

namespace GarageManager
{
    internal class Manager
    {
        private ConsoleUI ui = new ConsoleUI();

        GarageHandler garagehandler = new GarageHandler();
        Garage<IVehicle> garage;

        public void Start()
        {
            while (true)
            {
                MenuHelpers.ShowMainMenu();
                string input = ui.GetInput();

                switch (input)
                {
                    case MenuHelpers.Create:
                        garage = MakeNewGarage(garagehandler);
                        break;
                    case MenuHelpers.Manage:
                        //** CHECK THAT GARAGE EXISTS**//
                        if(garage != null)
                            ManageExistingGarage(garage, garagehandler);
                        else
                            ui.Print("No garages exist yet, please create one.");
                        break;
                    case MenuHelpers.Quit:
                        ui.Print("Thank you and Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        ui.Print("Not a valid selection!");
                        break;
                }
            }
        }

        public Garage<IVehicle> MakeNewGarage(GarageHandler garagehandler)
        {
            ui.Print("\nPlease enter the following details");

            uint capacity = Util.AskForNumber("How many spots should the garage have?: ");
            string popluate = Util.AskForInput("Would you like to populate the garage with some vehicles? (y/n): ");

            Garage<IVehicle> garage = null!;

            switch (popluate.ToLower())
            {
                case "y":
                    //List<IVehicle> vehiclesToPopulate = GenerateVehicles();
                    List<IVehicle> vehiclesToPopulate = SeedVehicles();
                    garage = garagehandler.CreateGarage(capacity, vehiclesToPopulate);
                    break;
                case "n":
                    garage = garagehandler.CreateGarage(capacity);
                    break;
                default:
                    break;
            }
            return garage;
        }

        
        public IVehicle GetVehicleDetails()
        {
            ui.Print("\nSelect type of vehicle: ");

            MenuHelpers.GetVehicleType();
            string type = ui.GetInput();

            string color = Util.AskForInput("Color: ");

            string registrationNumber = garagehandler.CheckRegistrationNumber(garage);
            uint numberOfWheels = Util.AskForNumber("Number of wheels: ");

            IVehicle newVehicle = VehicleFactory.MakeVehicle(type, registrationNumber, color, numberOfWheels);

            return newVehicle;
        }

        // When user is to enter vehicles
        public List<IVehicle> GenerateVehicles()
        {
            uint numberOfVehicles = Util.AskForNumber("How many vehicles?: ");
            List<IVehicle> vehiclesToAdd = new List<IVehicle>();

            for (int i = 0; i < numberOfVehicles; i++)
            {
                Console.WriteLine($"Select type for vehicle {i + 1}:");
                IVehicle newVehicle = GetVehicleDetails();
                vehiclesToAdd.Add(newVehicle);
            }
            return vehiclesToAdd;
        }

        // For testing purposes:
        public List<IVehicle> SeedVehicles()
        {
            List<IVehicle> vehiclesToAdd = new List<IVehicle>()
            {
                new Airplane("ABC123", "white", 8, 4),
                new Boat("ABD124", "white", 0, 40),
                new Bus("ABE125", "green", 6, 50),
                new Car("BEZ924", "yellow", 4, "gasoline"),
                new Motorcycle("DJO368", "black", 2, 200),
                new Airplane("KBRC893", "blue", 8, 4),
                new Boat("DLM354", "green", 0, 30),
                new Bus("RLP921", "green", 6, 50),
                new Car("SXB704", "yellow", 4, "gasoline"),
                new Motorcycle("GFW037", "black", 2, 200)
            };
            return vehiclesToAdd;
        }

        public void ManageExistingGarage(Garage<IVehicle> garage, GarageHandler garagehandler)
        {
            ui.Print("\nSelect an operation: ");

            MenuHelpers.ShowOperationMenu();
            string operation = ui.GetInput();

            switch (operation)
            {
                case MenuHelpers.Park:
                    garagehandler.Park(garage, GetVehicleDetails);
                    break;
                case MenuHelpers.Get:
                    string regNum = Util.AskForInput("Registration number: ");
                    garagehandler.GetVehicle(garage, regNum);
                    break;
                case MenuHelpers.View:
                    garagehandler.DisplayAllVehicles(garage);
                    break;
                case MenuHelpers.Search:
                    garagehandler.SearchGarage(garage);
                    break;
                default:
                    break;
            }
        }
    }
}
