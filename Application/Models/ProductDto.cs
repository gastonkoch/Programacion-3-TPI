using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductDto
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public IEnumerable<Order>? OrdersWithProducts { get; set; }

        public static ProductDto ToDto(Product product)
        {
            ProductDto dto = new ProductDto();
            dto.Name = product.Name;
            dto.Price = product.Price;
            dto.Description = product.Description;
            dto.Stock = product.Stock;
            dto.OrdersWithProducts = product.OrdersWithProducts;
            return dto;
        }
    }
}
