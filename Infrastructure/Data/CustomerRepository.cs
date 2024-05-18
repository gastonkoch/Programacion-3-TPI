using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        public ICollection<Customer> GetAll()
        {
            return null;
        }
    }
}
