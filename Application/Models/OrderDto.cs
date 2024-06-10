using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class OrderDto
    {
        //public int Id { get; set; }
        public int AmountProducts { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public User Customer { get; set; }
        public User Seller { get; set; }
        public IEnumerable<Product> ProductsInOrder { get; set; }

        public static OrderDto ToDto(Order order)
        {
            OrderDto dto = new OrderDto();
            //dto.Id = order.Id;
            dto.AmountProducts = order.AmountProducts;
            dto.PaymentMethod = order.PaymentMethod;
            dto.StatusOrder = order.StatusOrder;
            dto.Customer = order.Customer;
            dto.Seller = order.Seller;
            dto.ProductsInOrder = order.ProductsInOrder;
            return dto;
        }
    }
}
