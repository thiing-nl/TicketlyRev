using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Moq;
using Screend.Entities.Location;
using Screend.Entities.LostItem;
using Screend.Exceptions;
using Screend.Models.LostItem;
using Screend.Repositories;
using Screend.Services;
using Xunit;

namespace Screend.Tests.Services
{
    public class LostItemServiceTest
    {
        private static LostItemService _lostItemService;
        private static Mock<ILostItemRepository> _lostItemRepository;

        static LostItemServiceTest()
        {
            Helper.SetupAutoMapper();
            Setup();
        }
        
        private static void Setup()
        {
            _lostItemRepository = new Mock<ILostItemRepository>();
            var configuration = new Mock<IConfiguration>();

            var lostItems = new List<LostItem>
            {
                new LostItem
                {
                    Id = 1,
                    Email = "test@test.com",
                    State = LostItemState.Unknown,
                    Location = new Location(),
                    Description = "Shirt",
                    LocationId = 1,
                    PhoneNumber = ""
                },
                new LostItem
                {
                    Id = 2,
                    Email = "test@test.com",
                    State = LostItemState.Unknown,
                    Location = new Location(),
                    Description = "Pants",
                    LocationId = 1,
                    PhoneNumber = ""
                },
                new LostItem
                {
                    Id = 3,
                    Email = "test@test.com",
                    State = LostItemState.Unknown,
                    Location = new Location(),
                    Description = "Shoes",
                    LocationId = 2,
                    PhoneNumber = ""
                }
            };
                
            _lostItemRepository.Setup(lr => lr.GetByID(1)).Returns(lostItems[0]);
            _lostItemRepository.Setup(lr => lr.GetByID(2)).Returns(lostItems[1]);
            _lostItemRepository.Setup(lr => lr.GetByID(3)).Returns(lostItems[2]);
            _lostItemRepository.Setup(lr => lr.GetAllByLocationId(1))
                .Returns(lostItems.Where(it => it.LocationId == 1).ToArray());
            _lostItemRepository.Setup(lr => lr.GetAllByLocationId(2))
                .Returns(lostItems.Where(it => it.LocationId == 2).ToArray());
            
            _lostItemService = new LostItemService(_lostItemRepository.Object, configuration.Object);
        }
        
        [Fact]
        private void GetTest()
        {
            var lostItem1 = _lostItemService.GetById(1);
            Assert.IsType<LostItem>(lostItem1);
            Assert.Equal(lostItem1.Description, "Shirt");
            Assert.Equal(lostItem1.LocationId, 1);
            
            var lostItem2 = _lostItemService.GetById(2);
            Assert.IsType<LostItem>(lostItem2);
            Assert.Equal(lostItem2.Description, "Pants");
            Assert.Equal(lostItem2.LocationId, 1);
            
            var lostItem3 = _lostItemService.GetById(3);
            Assert.IsType<LostItem>(lostItem3);
            Assert.Equal(lostItem3.Description, "Shoes");
            Assert.Equal(lostItem3.LocationId, 2);
        }
        
        [Fact]
        private void GetTestFail()
        {
            Assert.Throws<NotFoundException>(() => _lostItemService.GetById(10));
        }
        
        [Fact]
        private void GetAllLocation1()
        {
            var lostItems = _lostItemService.GetAll(1);
            Assert.Equal(lostItems.Count(), 2);
        }
        
        [Fact]
        private void GetAllLocation2()
        {
            var lostItems = _lostItemService.GetAll(2);
            Assert.Equal(lostItems.Count(), 1);
        }
        
        [Fact]
        private void GetAllLocation3()
        {
            var lostItems = _lostItemService.GetAll(3);
            Assert.Equal(lostItems.Count(), 0);
        }
        
        [Fact]
        private void CreateLocation()
        {
            var lostItem = _lostItemService.Create(new LostItemCreateUpdateDTO
            {
                Email = "test@test.com",
                Description = "Pants",
                PhoneNumber = ""
            }, 1);
            
            Assert.IsType<LostItem>(lostItem);
            Assert.Equal(lostItem.LocationId, 1);
            
            _lostItemRepository.Verify(m => m.Insert(It.IsAny<LostItem>()), Times.AtLeast(1));
            _lostItemRepository.Verify(m => m.Commit(), Times.Once());
        }
        
        [Fact]
        private void DeleteLocation()
        {
            _lostItemService.Delete(1);
            _lostItemRepository.Verify(m => m.Delete(It.IsAny<LostItem>()), Times.AtLeast(1));
            _lostItemRepository.Verify(m => m.Commit(), Times.Once());
        }
    }
}