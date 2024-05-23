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
        // UTILIZAR DECORADORES SEGUNDA GRABACION 9:30
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string RegisterDate { get; set; }
        public UserType UserType { get; set; }

    }
}
