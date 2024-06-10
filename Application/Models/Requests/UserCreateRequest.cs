using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class UserCreateRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public UserType UserType { get; set; }

        public IEnumerable<OrderNotification>? OrderNotifications { get; set; } // NO SE ESTA USANDO
        public static User ToEntity(UserCreateRequest dto)
        {
            User user = new User();
            user.Name = dto.Name;
            user.Password = dto.Password;
            user.Email = dto.Email;
            user.RegisterDate = dto.RegisterDate;
            user.UserType = dto.UserType;
            user.OrderNotifications = dto.OrderNotifications;
            return user;
        }
    }
}

