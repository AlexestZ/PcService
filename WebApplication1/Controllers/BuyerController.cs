using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PcService.BL.Interfaces;
using PcService.DL.Interfaces;
using PcService.Models.DTO;
using PcService.Models.Requests;
using PcService.Models.Responses;

namespace PcService.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;
        private readonly IMapper _mapper;
        public BuyerController(IBuyerService buyerService, IMapper mapper)
        {
            _buyerService =buyerService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]         
        public IActionResult GetAll()
        {
           var result = _buyerService.GetAll();

            if (result != null) return Ok(result);

            return NoContent();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _buyerService.GetbyId(id);

            if (result != null) return Ok(result);

            var response = _mapper.Map<BuyerResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]

        public IActionResult CreateBuyer([FromBody]BuyerRequest buyerRequest)
        {
            if (buyerRequest == null) return BadRequest();

            var buyer = _mapper.Map<Buyer>(buyerRequest);

            var result = _buyerService.Create(buyer);

            return Ok(result);
        }

        [HttpDelete("Delete")]

        public IActionResult Delete(int id)
        {
            if ( id <= 0) return BadRequest();

            var result = _buyerService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]

        public IActionResult Update([FromBody] Buyer buyer)
        {
            if ( buyer == null) return BadRequest();

            var searchBuyer = _buyerService.GetbyId(buyer.Id);

            if (searchBuyer == null) return NotFound(buyer);

            var result = _buyerService.Update(buyer);

            if (result != null) return Ok(result);

            return NotFound(result);
        }
    }
}
 