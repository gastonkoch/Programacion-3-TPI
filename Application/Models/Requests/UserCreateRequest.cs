using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class UserCreateRequest
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public UserType UserType { get; set; }

        //public IEnumerable<OrderNotification>? OrderNotifications { get; set; }

        public static User ToEntity(UserCreateRequest dto)
        {
            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                LastName = dto.LastName,
                Password = dto.Password,
                Email = dto.Email,
                RegisterDate = dto.RegisterDate,
                UserType = dto.UserType,
                //OrderNotifications = dto.OrderNotifications
            };
        }
    }
}
