using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PcService.BL.Interfaces;
using PcService.BL.Services;
using PcService.DL.Interfaces;
using PcService.Models.DTO;
using PcService.Models.Requests;
using PcService.Models.Responses;

namespace PcService.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaptopController : ControllerBase
    {
        private readonly ILaptopService _laptopService;
        private readonly IMapper _mapper;
        public LaptopController(ILaptopService laptopService, IMapper mapper)
        {
            _laptopService = laptopService;
            _mapper = mapper;
        }

        public IActionResult GetAll()
        {
            var result = _laptopService.GetAll();

            if (result != null) return Ok(result);

            return NoContent();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _laptopService.GetbyId(id);

            if (result != null) return Ok(result);

            var response = _mapper.Map<LaptopResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]

        public IActionResult Create([FromBody] LaptopRequest laptopRequest)
        {
            if (laptopRequest == null) return BadRequest();

            var laptop = _mapper.Map<Laptop>(laptopRequest);

            var result = _laptopService.Create(laptop);

            return Ok(result);
        }

        [HttpDelete("Delete")]

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _laptopService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]

        public IActionResult Update([FromBody] Laptop laptop)
        {
            if (laptop == null) return BadRequest();

            var searchLaptop = _laptopService.GetbyId(laptop.Id);

            if (searchLaptop == null) return NotFound(laptop);

            var result = _laptopService.Update(laptop);

            if (result != null) return Ok(result);

            return NotFound(result);
        }
    }
}
