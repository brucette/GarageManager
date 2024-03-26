using GarageManager.Vehicles;
using GarageManager.Vehicles.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager
{
    internal interface IHandler
    {
        public Garage<IVehicle> CreateGarage(string name, uint capacity);

        void Park(Garage<IVehicle> garage, IVehicle vehicle);

        void GetVehicle(Garage<IVehicle> garage, IVehicle vehicle);

        void DisplayAllVehicles(Garage<IVehicle> garage);

        //Vehicle SearchGarage();

    }
}
