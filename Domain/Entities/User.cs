using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public string RegisterDate { get; set; }

        [Required]
        public UserType UserType { get; set; }

        //public IEnumerable<OrderNotification> Notifications { get; set; } Descomentar cuando tengamos creada esa clase

    }
}
