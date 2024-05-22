using Application.Interfaces;
using Application.Models;
using Domain.Entities;
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

        [HttpGet]
        public ActionResult<ICollection<Customer>> GetAllCustomer()
        {
            try
            {
                return Ok(_customerService.GetAllCustomer());
            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById([FromRoute] int id)
        {
            try
            {
                return Ok(GetCustomerById(id));
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public void Update([FromRoute] int id,[FromBody] CustomerDto customer)
        {
            _customerService.Update(id, customer);  
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _customerService.Delete(id);
        }

        [HttpPost]
        public ActionResult<Customer> Create([FromBody] CustomerDto customer)
        {
            _customerService.Create(customer);

            try
            {
                return Ok(_customerService.GetCustomerById(customer.Id));
            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
