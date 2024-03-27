using GarageManager.Helpers;
using GarageManager.Vehicles;
using System.Collections;
using System.Linq;
using System.Text;

namespace GarageManager
{
    // HAVE IEnumerable<T> ON Garage OR ON IVehicle?? 
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private readonly uint numberOfSpots;
        private T[] vehicles;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null)
                    sb.Append($"{vehicles[i].ToString()}\n");
            }
            return sb.ToString();
        }

        public Garage(uint capacity)
        {
            numberOfSpots = capacity;
            vehicles = new T[numberOfSpots];

            Util.PrintWithColour($"Garage created!", ConsoleColor.Green);
        }
        
        public Garage(uint capacity, List<IVehicle> toBepopluated)
        {
            numberOfSpots = capacity;
            vehicles = new T[numberOfSpots];  

            foreach (T vehicle in toBepopluated)
            {
                AddVehicle(vehicle);
            }

            Util.PrintWithColour($"Garage created and vehicle(s) successfully added!", ConsoleColor.Green);
        }

        // Do a null check here?
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                yield return item;
            }
        }

        // Explicit interface implementation
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool SearchByRegistration(string registration)
        {
            // Convert the registration number to uppercase
            string upperCaseRegistration = registration.ToUpper();

            foreach (var item in vehicles)
            {
                if (item != null)
                    if (item.RegistrationNumber == registration)
                        return true;
            }
            return false;
        }

        public void AddVehicle(T vehicle) 
        {
            int firstEmptySpot = Array.FindIndex(vehicles, veh => veh == null);

            if (firstEmptySpot >= 0)
            {
                vehicles[firstEmptySpot] = vehicle;
                Util.PrintWithColour("Vehicle was parked!", ConsoleColor.Green);
            }
            else 
            {
                Util.PrintWithColour("Sorry, the garage is full, could not park your vehicle!", ConsoleColor.DarkRed);
            }
        }

        public void RemoveVehicle(string registrationNumber)
        {
            //int locationOfVehicle = Array.IndexOf(vehicles, vehicle);
            bool vehicleInGarage = SearchByRegistration(registrationNumber);

            if (vehicleInGarage)
            {
                int locationOfVeh = Array.FindIndex(vehicles, veh => veh.RegistrationNumber == registrationNumber);
                Console.WriteLine();
                if (locationOfVeh >= 0)
                {
                    vehicles[locationOfVeh] = default;
                    Util.PrintWithColour("Vehicle removed from garage!", ConsoleColor.Green);
                }
                else
                {
                    Util.PrintWithColour("Sorry, that vehicle was not found, please check registration number and try again.", ConsoleColor.DarkRed);
                }
            }
        }

        public void FilterVehicles(Dictionary<string, string> validSearchTerms)
        {
            string colour        = validSearchTerms["colour"];
            string typeOfVehicle = validSearchTerms["typeOfVehicle"];
            uint numberOfWheels;
            uint.TryParse(validSearchTerms["numberOfWheels"], out numberOfWheels);

            //    // Loop through the dictionary
            //    foreach (KeyValuePair<string, string> kvp in validSearchTerms)
            //    {
            //        string key = kvp.Key;
            //        string value = kvp.Value;
            //        if (key == "numberOfWheels")
            //        {
            //            uint.TryParse(key, out uint converted);
            //        }
            //        Console.WriteLine($"Key: {key}, Value: {value}");
            //    }

            IEnumerable<T> found = vehicles.Where(
                vehicle => vehicle.Colour.ToLower() == colour
                && vehicle.GetType().Name.ToLower() == typeOfVehicle
                && vehicle.NumberOfWheels == numberOfWheels);
        }

        public void ShowVehicleDetails()
        {
            foreach (var item in vehicles)
            {
                if (item != null)
                Console.WriteLine($"Type: {item.GetType().Name}");
            }

            IEnumerable<T> cars = vehicles.Where(vehicle => vehicle.GetType().Name == "Car");
            IEnumerable<T> airplanes = vehicles.Where(vehicle => vehicle.GetType().Name == "Airplane");
            IEnumerable<T> motorcycles = vehicles.Where(vehicle => vehicle.GetType().Name == "Motorcycle");
            IEnumerable<T> busses = vehicles.Where(vehicle => vehicle.GetType().Name == "Bus");
            IEnumerable<T> boats = vehicles.Where(vehicle => vehicle.GetType().Name == "Boat");
        }
    }
}
 