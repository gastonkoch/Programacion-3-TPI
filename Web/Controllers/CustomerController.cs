using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        // ESTO HAY QUE REVISARLO BIEN
        [HttpPost]
        [Route("add")]
        public IActionResult AddUser([FromBody] CustomerDto customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is null");
            }

            try
            {
                int result = _customerService.AddUser(customer);
                return Ok(new { Id = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
