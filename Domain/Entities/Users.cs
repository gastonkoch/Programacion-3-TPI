using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Users
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "datetime")]
        public string RegisterDate { get; set; }

        //public List<OrderNotification> Notifications { get; set; } Descomentar cuando tengamos creada esa clase
    }
}
