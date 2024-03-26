using GarageManager.Vehicles;
using GarageManager;
    
namespace GarageManager.Tests
{
    public class GarageTests
    {
        [Fact]
        public void CreateGarage_Creates_A_Garage()
        {
            // Arrange
            GarageHandler garageHandler = new GarageHandler();

            int capacity = 20;
            // Act
            Garage<IVehicle> garage = garageHandler.CreateGarage(capacity);

            // Assert
            Assert.Equal(20, garage.Length);    
        }
    }
}