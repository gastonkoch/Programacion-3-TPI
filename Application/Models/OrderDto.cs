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
        public int Id { get; set; }
        public int AmountProducts { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StatusOrder StatusOrder { get; set; }  
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
    }
}
