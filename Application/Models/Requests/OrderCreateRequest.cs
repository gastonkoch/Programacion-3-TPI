using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class OrderCreateRequest
    {
        [Required]
        public int AmountProducts { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public StatusOrder StatusOrder { get; set; }

        [Required]
        public User Customer { get; set; }

        [Required]
        public User Seller { get; set; }

        [Required]
        public IEnumerable<Product> ProductsInOrder { get; set; }

        public static Order ToEntity(OrderCreateRequest dto)
        {
            Order order = new Order();
            order.AmountProducts = dto.AmountProducts;
            order.PaymentMethod = dto.PaymentMethod;
            order.StatusOrder = dto.StatusOrder;
            order.Customer = dto.Customer; 
            order.Seller = dto.Seller;
            order.ProductsInOrder = dto.ProductsInOrder;
            return order;
        }
    }
}
