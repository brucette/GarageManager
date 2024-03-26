using GarageManager.Helpers;
using GarageManager.Vehicles;
using System.Collections;

namespace GarageManager
{
    // internal class Garage<T> where T : IVehicle, IEnumerable<T>
    // HAVE IEnumerable<T> ON Garage OR ON IVehicle?? 
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private readonly uint numberOfSpots;
        private T[] vehicles;
        //public string garageName;
        public List<int> availableSpots = new List<int>();
        public string Name { get; set; }

        // ******************************************************
        public void printAvailableSpots()
        {
            Console.WriteLine(" Available spots in the list");
            foreach (var item in availableSpots) 
            {
                Console.WriteLine($" {item}");
            }
            Console.WriteLine();
        }
        public void printGarage()
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                    Console.WriteLine("Empty spot! {0}", i); 
                else
                    Console.WriteLine(vehicles[i].GetType().Name);
            }
        }
        // ******************************************************

        public int Length => vehicles.Length;

        public override string ToString()
        {
            return base.ToString();
        }

        public void GetAvailableSpots(T[] vehicles)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                    availableSpots.Add(i);
            };
        }

        public bool isFull => availableSpots.Count == 0;

        public Garage(string name, uint capacity)
        {
            //garageName = name;
            numberOfSpots = capacity;
            vehicles = new T[numberOfSpots];
            Console.WriteLine($"length of array: {vehicles.Length}");
            Name = name;
            GetAvailableSpots(vehicles);
            //printAvailableSpots();

            Util.PrintWithColour($"{Name} garage created!", ConsoleColor.Green);
        }
        
        public Garage(string name, uint capacity, List<IVehicle> toBepopluated)
        {
            //garageName = name;
            numberOfSpots = capacity;
            vehicles = new T[numberOfSpots];  
            Name = name;
            GetAvailableSpots(vehicles);
            //printAvailableSpots();

            foreach (T vehicle in toBepopluated)
            {
                AddVehicle(vehicle);
            }

            Util.PrintWithColour($"{Name} garage created and vehicle(s) successfully added!", ConsoleColor.Green);
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

        public void AddVehicle(T vehicle) 
        {
                int firstAvailableSpot = availableSpots[0];
                vehicles[firstAvailableSpot] = vehicle;
                availableSpots.RemoveAt(0);
            
                Util.PrintWithColour("Vehicle was parked!", ConsoleColor.Green);

                // CHECK:
                //Console.WriteLine("Available spots after parking: ");
                //printAvailableSpots();
                //Console.WriteLine("Garage: ");
                //printGarage();
        }

        public void RemoveVehicle(T vehicle, string registrationNumber)
        {
            int locationOfVehicle = Array.IndexOf(vehicles, vehicle);
            vehicles[locationOfVehicle] = default;
            Util.PrintWithColour("Vehicle removed from garage!", ConsoleColor.Green);
            
            // CHECK:
            Console.WriteLine("Garage: ");
            printGarage();
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
 