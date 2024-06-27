using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UserDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [Required]
        public UserType UserType { get; set; }

        //public IEnumerable<OrderNotification>? OrderNotifications { get; set; }

        public static UserDto ToDto(User User)
        {
            UserDto dto = new UserDto();
            dto.Id = User.Id;
            dto.Name = User.Name;
            dto.LastName = User.LastName;
            dto.Password = User.Password;
            dto.Email = User.Email;
            dto.RegisterDate = User.RegisterDate;
            dto.UserType = User.UserType;
            //dto.OrderNotifications = User.OrderNotifications;
            return dto;
        }

        public static List<UserDto> ToList(ICollection<User> users)
        {
            List<UserDto> listUsersDto = new List<UserDto>();

            foreach (var user in users)
            {
                listUsersDto.Add(UserDto.ToDto(user));
            }
            return listUsersDto;
        }
    }
}
