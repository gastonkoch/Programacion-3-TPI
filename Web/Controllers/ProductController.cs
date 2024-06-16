using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<ICollection<Product>> GetAllUsers()
        {
            try
            {
                return Ok(_productService.GetAllProducts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProductById([FromRoute]int id)
        {
            try
            {
                return Ok(_productService.GetProductById(id));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct([FromBody] ProductCreateRequest product)
        {
            try
            {
                return Ok(_productService.CreateProduct(product));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public void UpdateProduct([FromRoute] int id, [FromBody] ProductCreateRequest product)
        {
            _productService.UpdateProduct(id, product);
        }


        [HttpDelete("{id}")]
        public void DeleteProduct([FromRoute] int id)
        {
            _productService.DeleteProduct(id);
        }

    }
}
