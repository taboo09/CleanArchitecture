using System.Collections.Generic;
using AutoMapper;
using Clean.API.Controllers;
using Clean.API.Tests.Repository;
using Clean.Data.Dtos;
using Clean.Data.Entities;
using Clean.Data.Interfaces;
using Clean.Infrastructure.Mapping;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Clean.API.Tests.Controllers
{
    public class ValuesControllerTest
    {
        private ValuesController _controller;
        private IAppRepository<Homes> _appReo;
        private HomeDto _newHome;
        private IMapper _mapper;

        public ValuesControllerTest()
        {
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            _mapper = mockMapper.CreateMapper();

            _appReo = new AppRepositoryFake();
            _controller = new ValuesController(_appReo, _mapper);
            _newHome = new HomeDto()
            {
                Id = 4,
                Name = "Test",
                City = "Liverpool",
                Address = "7 Street",
                Email = "Test@test.com",
                Rating = 5
            };
        }

        [Fact]
        public void Get_WhenCalled_ReturnOk()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnAllItems()
        {
            // Act
            var result = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Homes>>(result.Value);

            Assert.Equal(3, items.Count);
        }

        [Fact]
        public async void GetById_NegativeOrZeroId_ReturnsBadRequest()
        {
            // Arrange
            var id = 0;

            // Act
            var badRequestResult = await _controller.Get(id) as BadRequestObjectResult;

            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequestResult);
        }

        [Fact]
        public async void GetById_UnknownId_ReturnsNotFound()
        {
            // Arrange
            var id = 5;

            // Act
            var notFoundResult = await _controller.Get(id) as NotFoundObjectResult;

            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsOk()
        {
            // Arrange
            var id = 1;

            // Act
            var okResult = _controller.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsTheFoundedObject()
        {
            // Arrange
            var id = 1;

            // Act
            var okResult = _controller.Get(id).Result as OkObjectResult;

            // Assert
            Assert.IsType<Homes>(okResult.Value);
            Assert.Equal(id, (okResult.Value as Homes).Id);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            _newHome.Rating = 8; //setting rating over 5

            _controller.ModelState.AddModelError("Rating", "Range");

            // Act
            var response = _controller.Post(_newHome);

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsOk()
        {
            // Act
            var response = _controller.Post(_newHome);
            
            // Assert
            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public async void Add_ValidObjectPassed_ReturnsOkPassingNewItem()
        {
            // Act
            var createdResponse = await _controller.Post(_newHome) as OkObjectResult;

            var obj = createdResponse.Value as Homes;

            // Assert
            Assert.IsType<Homes>(obj);
            Assert.Equal("Test", obj.Name);
        }

        [Fact]
        public void Delete_NegativeOrZeroId_ReturnsBadRequest()
        {
            // Arrange
            var id = 0;

            // Act
            var badRequestResult = _controller.Delete(id).Result as BadRequestObjectResult;

            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequestResult);
        }

        [Fact]
        public void Delete_UnknownId_ReturnsNotFound()
        {
            // Arrange
            var id = 4;

            // Act
            var notFoundResult = _controller.Delete(id).Result as NotFoundObjectResult;

            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }

        [Fact]
        public void Delete_ExistingId_ReturnsOk()
        {
            // Arrange
            var id = 2;

            // Act
            var okResult = _controller.Delete(id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public async void Delete_ExistingId_RemoveOneItem()
        {
            // Arrange
            var id = 2;

            // Act
            var okResult = _controller.Delete(id);
            var listCount = (await _appReo.ListAllAsync()).Count;

            // Assert
            Assert.Equal(2, listCount);
        }
    }
}