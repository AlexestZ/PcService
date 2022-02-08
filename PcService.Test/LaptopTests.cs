using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PcService.BL.Interfaces;
using PcService.BL.Services;
using PcService.DL.Interfaces;
using PcService.Host.Controllers;
using PcService.Host.Extensions;
using PcService.Models.DTO;
using PcService.Models.Requests;
using PcService.Models.Responses;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace PcService.Test
{
    public class LaptopTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILaptopRepository> _laptopRepository;
        private readonly ILaptopService _laptopService;
        private readonly LaptopController _laptopController;

        private IList<Laptop> Laptops = new List<Laptop>()
        {
        { new Laptop() { Id = 8, Name = "Test Name"} },
        { new Laptop() { Id = 9, Name = "Test Name2"} }
        };

        public LaptopTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _laptopRepository = new Mock<ILaptopRepository>();
             
            var logger = new Mock<ILogger>();

            _laptopService = new laptopService(_laptopRepository.Object, logger.Object);

            _laptopController = new LaptopController(_laptopService, _mapper);
        }

        [Fact]
        public void Laptop_GetAll_Count_Check()
        {
            var expectedCount = 2;

            var mockedService = new Mock<ILaptopService>();

            mockedService.Setup(x => x.GetAll()).Returns(Laptops);

            var controller = new LaptopController(mockedService.Object, _mapper);

            var result = controller.GetAll();

            var OkObjectResult = result as OkObjectResult;
            Assert.NotNull(OkObjectResult);
            Assert.Equal(OkObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var laptops = OkObjectResult.Value as IEnumerable<Laptop>;
            Assert.NotNull(laptops);
            Assert.Equal(expectedCount, laptops.Count());
        
        }

        [Fact]
        public void Laptop_GetById_NameCheck()
        {           
            var laptopId = 8;
            var expectedName = "Test Name2";

            _laptopRepository.Setup(x => x.GetbyId(laptopId))
                .Returns(Laptops.FirstOrDefault(x => x.Id == laptopId));

            var result = _laptopController.GetById(laptopId);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as LaptopResponse;
            var laptop = _mapper.Map<Laptop>(response);

            Assert.NotNull(laptop);
            Assert.Equal(expectedName, laptop.Name);
        }

        [Fact]
        public void Laptop_GetById_NotFound()
        {           
            var laptopId = 3;

            _laptopRepository.Setup(x => x.GetbyId(laptopId))
                .Returns(Laptops.FirstOrDefault(x => x.Id == laptopId));
           
            var result = _laptopController.GetById(laptopId);
          
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
        }

        [Fact]
        public void Laptop_Update_LaptopName()
        {          
            var laptopId = 210;
            var expectedLaptopName = "New Laptop Name";

            var laptop = Laptops.FirstOrDefault(x => x.Id == laptopId);
            laptop.Name = expectedLaptopName;

            _laptopRepository.Setup(x => x.GetbyId(laptop.Id)).Returns(Laptops.FirstOrDefault(x => x.Id == laptopId));
            _laptopRepository.Setup(x => x.Update(laptop)).Returns(Laptops.FirstOrDefault(x => x.Id == laptopId));

            var result = _laptopController.Update(laptop);

            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var pos = okObjectResult.Value as LaptopResponse;
            Assert.NotNull(pos);
            Assert.Equal(expectedLaptopName, pos.Name);
        }
        [Fact]
        public void Tag_Delete_Existing_PositionName()
        {
            //setup
            var laptopId = 201;

            var laptop = Laptops.FirstOrDefault(x => x.Id == laptopId);

            _laptopRepository.Setup(x => x.Delete(laptopId)).Callback(() => Laptops.Remove(laptop));

            var result = _laptopController.Delete(laptopId);
                      
            var okObjectResult = result as StatusCodeResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.Null(Laptops.FirstOrDefault(x => x.Id == laptopId));
        }

        [Fact]
        public void Laptop_Delete_NotExisting_PositionName()
        {
            var laptopId = 3;

            var position =Laptops.FirstOrDefault(x => x.Id == laptopId);

            _laptopRepository.Setup(x => x.Delete(laptopId)).Callback(() => Laptops.Remove(position));

            var result = _laptopController.Delete(laptopId);

            Assert.Null(Laptops.FirstOrDefault(x => x.Id == laptopId));
        }

        [Fact]
        public void Laptop_Create_PositionName()
        {
            //setup
            var laptop = new Laptop()
            {
                Id = 203,
                Name = "Name 3",
            };

            _laptopRepository.Setup(x => x.GetAll())
                .Returns(Laptops);

            _laptopRepository.Setup(x => x.Create(It.IsAny<Laptop>())).Callback(() =>
            {
                Laptops.Add(laptop);
            }).Returns(new Laptop()
            {
                Id = 203,
                Name = "Name 3",
            });

            var result = _laptopController.Create(_mapper.Map<LaptopRequest>(laptop));

            var okObjectResult = result as OkObjectResult;
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            Assert.NotNull(Laptops.FirstOrDefault(x => x.Id == laptop.Id));
        }

    }
}
