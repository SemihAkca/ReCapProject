using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IRentalServices _rentalServices;

        public RentalsController(IRentalServices rentalServices)
        {
            _rentalServices = rentalServices;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalServices.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalServices.Add(rental);
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalServices.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Post(Rental rental)
        {
            var result = _rentalServices.Update(rental);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalServices.Delete(rental);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
