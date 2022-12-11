using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarServices _carServices;

        public CarsController(ICarServices carServices)
        {
            _carServices = carServices;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carServices.GetAll();
            if (result.Succes)
            {
                Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carServices.Add(car);
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _carServices.GetCarsByBrandId(id);
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carServices.GetCarsByColorId(id);
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carServices.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Post(Car car)
        {
            var result = _carServices.Update(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carServices.Delete(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
