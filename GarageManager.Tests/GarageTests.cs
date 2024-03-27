using GarageManager.Vehicles;
using GarageManager;
    
namespace GarageManager.Tests
{
    public class GarageTests
    {
        [Fact]
        public void Garage_Creates_A_Garage()
        {
            // Arrange
            uint capacity = 20;

            // Act
            Garage<IVehicle> garage = new Garage<IVehicle>(capacity);

            // Assert
            Assert.NotNull(garage);
            Assert.Equal(20, garage.Length);    
        }
        
        //ToDO
        //public void Garage_Creates_A_Populated_Garage()
        //{
        //    Arrange
        //    uint capacity = 20;
        //    List<IVehicle> vehiclesToAdd = new List<IVehicle>()
        //    {
        //        new Airplane("ABC123", "white", 8, 4),
        //        new Boat("ABD124", "white", 0, 40),
        //        new Bus("ABE125", "green", 6, 50)
        //    };

        //    Act
        //    Garage<IVehicle> garage = new Garage<IVehicle>(capacity);

        //    Assert
        //    Assert.NotNull(garage);
        //    Assert.Equal(20, garage.Length);

        //    foreach (IVehicle vehicle in vehiclesToAdd)
        //    {
        //        Assert.Contains(vehicle, garage.vehicles);
        //    }
        //}

        ////ToDO
        //public void SearchByRegistration_Returns_Boolean()
        //{
        // Arrange

        // Act

        // Assert
        //}
    }
}

        