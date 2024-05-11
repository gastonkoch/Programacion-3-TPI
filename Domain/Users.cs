using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RegisterDate { get; set; }

        //public List<OrderNotification> Notifications { get; set; } Descomentar cuando tengamos creada esa clase

        public Users(int id, string name, string password, string email, string registerDate)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            RegisterDate = registerDate;
        }
    }
}
