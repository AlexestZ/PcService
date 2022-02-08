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
    public class PersonalComputerController : ControllerBase
    {
        private readonly IPersonalComputerService _personalComputerService;
        private readonly IMapper _mapper;
        public PersonalComputerController(IPersonalComputerService PersonalComputerService, IMapper mapper)
        {
            _personalComputerService = PersonalComputerService;
            _mapper = mapper;
        }

        public IActionResult GetAll()
        {
            var result = _personalComputerService.GetAll();

            if (result != null) return Ok(result);

            return NoContent();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _personalComputerService.GetbyId(id);

            if (result != null) return Ok(result);

            var response = _mapper.Map<PersonalComputerResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]

        public IActionResult CreatepersonalComputer([FromBody] PersonalComputerRequest personalComputerRequest)
        {
            if (personalComputerRequest == null) return BadRequest();

            var personalComputer = _mapper.Map<PersonalComputer>(personalComputerRequest);

            var result = _personalComputerService.Create(personalComputer);

            return Ok(result);
        }

        [HttpDelete("Delete")]

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _personalComputerService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]

        public IActionResult Update([FromBody] PersonalComputer personalComputer)
        {
            if (personalComputer == null) return BadRequest();

            var searchPersonalComputer = _personalComputerService.GetbyId(personalComputer.Id);

            if (searchPersonalComputer == null) return NotFound(personalComputer);

            var result = _personalComputerService.Update(personalComputer);

            if (result != null) return Ok(result);

            return NotFound(result);
        }
    }
   
}

