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

        [HttpGet("/GetAllCustomer")]
        public ActionResult<ICollection<Customer>> GetAllCustomer()
        {
            try
            {
                return Ok(_customerService.GetAllCustomer());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/GetElementById")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            try
            {
                return Ok(GetCustomerById(id));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/Update")]
        public void Update(int id, CustomerDto customer)
        {
            _customerService.Update(id, customer);  
        }

        [HttpDelete("/Delete")]
        public void Delete(int id)
        {
            _customerService.Delete(id);
        }
        [HttpPost("/Create")]
        public ActionResult<Customer> Create(CustomerDto customer)
        {
            _customerService.Create(customer);

            try
            {
                return Ok(_customerService.GetCustomerById(customer.Id));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
