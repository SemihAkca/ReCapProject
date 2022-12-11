using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerServices _customerServices;

        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerServices.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerServices.Add(customer);
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _customerServices.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Post(Customer customer)
        {
            var result = _customerServices.Update(customer);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerServices.Delete(customer);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

