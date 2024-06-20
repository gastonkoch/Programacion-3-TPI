using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class OrderNotificationCreateRequest
    {
        public string Message { get; set; }
        public Order Order { get; set; }
        //public IEnumerable<User>? User { get; set; }

        public static OrderNotification ToEntity(OrderNotificationCreateRequest dto)
        {
            OrderNotification orderNotification = new OrderNotification();
            orderNotification.Message = dto.Message;
            orderNotification.Order = dto.Order;
            //orderNotification.User = dto.User;
            return orderNotification;
        }
    }
}
