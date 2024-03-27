using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Vehicles
{
    public interface IVehicle
    {
        string RegistrationNumber { get; set; }
        string Colour { get; set; }
        uint NumberOfWheels { get; set; }
    }
}
