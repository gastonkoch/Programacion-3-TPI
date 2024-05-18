using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Customer : User
    {
        // Esto no se si esta bien, pero lo creo hoy 18/05/2024 por que no dimos como usar el dato
        // Con esto me permite hacer un metodo Create() desde la capa Application => Services
        public Customer(int id, string name, string password, string email,string registerDate)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            RegisterDate = registerDate;
        }

        public Customer(string password)
        {
            Password = password;
        }
    }
}
