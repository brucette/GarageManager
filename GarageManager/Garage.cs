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
        public string garageName;
        public List<int> availableSpots = new List<int>();
        public string Name { get; set; }

        // ******************************************************
        public void printAvailableSpots()
        {
            //for (int i = 0; i < availableSpots.Count; i++)
            //{
            //    Console.WriteLine(i);
            //}
            foreach(var item in availableSpots) 
            {
                Console.WriteLine(item);
            }
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

        public void GetAvailableSpots(T[] vehicles)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                    availableSpots.Add(i);
            };
            //availableSpots = vehicles.Where(x => x == null)
            //.Select(x => Array.IndexOf(vehicles, x)).ToList();
        }

        //public List<int> AvailableSpots
        //{
        //    get { return availableSpots; }
        //    set 
        //    {
        //        foreach (T vehicle in vehicles)
        //        {
        //            if (vehicle == null)
        //                availableSpots.Add(Array.IndexOf(vehicles, vehicle));
        //        };
        //    }
        //}

        public bool isFull => availableSpots.Count < 1;

        public Garage(string name, uint capacity)
        {
            garageName = name;
            numberOfSpots = capacity;
            vehicles = new T[numberOfSpots];
            Name = name;
            GetAvailableSpots(vehicles);
            printAvailableSpots();

            Util.PrintWithColour($"{Name} garage created!", ConsoleColor.Green);
        }
        
        public Garage(string name, uint capacity, List<IVehicle> toBepopluated)
        {
            garageName = name;
            numberOfSpots = capacity;
            vehicles = new T[numberOfSpots];
            Name = name;


            int index = 0;
            foreach (T vehicle in toBepopluated)
            {
                vehicles[index] = vehicle;
                index++;
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
            if (isFull)
            {
                Console.WriteLine("Sorry, the garage is full!");
            }
            else
            {
                int firstAvailableSpot = availableSpots[0];
                vehicles[firstAvailableSpot] = vehicle;
                availableSpots.RemoveAt(0);
                Console.WriteLine("Vehicle was parked!");

                // CHECK:
                Console.WriteLine("Available spots after parking: ");
                printAvailableSpots();
                Console.WriteLine("Garage: ");
                printGarage();
            }
        }

        public void RemoveVehicle(T vehicle, string registrationNumber)
        {
            int locationOfVehicle = Array.IndexOf(vehicles, vehicle);
            vehicles[locationOfVehicle] = default;
            Console.WriteLine("Vehicle removed!");
            Console.WriteLine("Garage: ");
            printGarage();
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
 