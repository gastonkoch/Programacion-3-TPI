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
        public UserDto Customer { get; set; }
        public UserDto Seller { get; set; }
        public IEnumerable<ProductDto> ProductsInOrder { get; set; }


        public static OrderDto ToDto(Order order)
        {
            OrderDto dto = new OrderDto();
            //dto.Id = order.Id;
            dto.AmountProducts = order.AmountProducts;
            dto.PaymentMethod = order.PaymentMethod;
            dto.StatusOrder = StatusOrder.InProgress;

            dto.Customer = UserDto.ToDto(order.Customer);
            dto.Seller = UserDto.ToDto(order.Seller);
            dto.ProductsInOrder = ProductDto.ToList(order.ProductsInOrder);
            return dto;
        }
    }
}
