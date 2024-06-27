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
        //[Required]
        //public Order Order { get; set; }

        ////public IEnumerable<User>? User { get; set; }

        public static OrderNotificationDto todto(OrderNotificationDto ordernotification)
        {
            OrderNotificationDto dto = new OrderNotificationDto();
            {
                dto.Message = ordernotification.Message;
                //dto.order = ordernotification.order;
                //dto.user = ordernotification.user;
                return dto;
            }
        }
    }
}
