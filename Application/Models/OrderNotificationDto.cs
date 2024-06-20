using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class OrderNotificationDto
    {
        //public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public Order Order { get; set; }

        //public IEnumerable<User>? User { get; set; }

        public static OrderNotificationDto ToDto(OrderNotification orderNotification)
        {
            OrderNotificationDto dto = new OrderNotificationDto();
            {
                dto.Message = orderNotification.Message;
                dto.Order = orderNotification.Order;
                //dto.User = orderNotification.User;
                return dto;
            }
        }
    }
}
