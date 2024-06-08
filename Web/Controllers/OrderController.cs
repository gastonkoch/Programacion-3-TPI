using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<ICollection<Order>> GetAll()
        {
            try
            {
                return Ok(_orderService.GetAll());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById([FromRoute] int id)
        {
            try
            {
                return Ok(_orderService.GetOrderById(id));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] OrderDto order)
        {
            try
            {
                return _orderService.CreateOrder(order);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public void UpdateOrder([FromRoute]int id, [FromBody] OrderDto order)
        {
            _orderService.UpdateOrder(id, order);
        }

        [HttpDelete("{id}")]
        public void DeleteOrder([FromRoute] int id)
        {
            _orderService.DeleteOrder(id);
        }

    }
}
