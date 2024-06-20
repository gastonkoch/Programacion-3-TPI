using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class ProductCreateRequest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Stock { get; set; }

        //public IEnumerable<Order>? OrdersWithProducts { get; set; }

        public static Product ToEntity(ProductCreateRequest dto)
        {
            Product product = new Product();
            product.Id = dto.Id;
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Description = dto.Description;
            product.Stock = dto.Stock;
            //product.OrdersWithProducts = dto.OrdersWithProducts;
            return product;
        }
    }
}
