using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Seller : Users
    {
        public Seller(int id, string name, string password, string email, string registerDate)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            RegisterDate = registerDate;
        }
    }
}
