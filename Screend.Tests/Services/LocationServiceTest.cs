using System.Collections.Generic;
using Moq;
using Screend.Entities.Location;
using Screend.Repositories;
using Screend.Services;
using Xunit;

namespace Screend.Tests.Services
{
    public class LocationServiceTest
    {

        private static LocationService _locationService;
        
        static LocationServiceTest()
        {
            Setup();
        }

        private static void Setup()
        {
            var locationRepository = new Mock<ILocationRepository>();

            locationRepository.Setup(lr => lr.GetByID(1)).Returns(new Location
            {
                Id = 1,
                Name = "TestLocatie",
                Address = "Testadres 1, testlocatie",
            });
            
            _locationService = new LocationService(locationRepository.Object);
        }
        
        [Fact]
        private void GetTest()
        {
            var location = _locationService.Get(1);
            Assert.IsType<Location>(location);
        }
        
        [Fact]
        private void CheckIfExistsTest()
        {
            var locationExists = _locationService.CheckExists(1);
            Assert.True(locationExists);
        }
    }
}