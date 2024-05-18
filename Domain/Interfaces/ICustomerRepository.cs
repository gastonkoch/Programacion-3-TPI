using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  
namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetAll();
        Customer GetCustomerById(int id);
        Customer Add(Customer customer); // Create
        void Delete(Customer customer);
        void Update(Customer customer);
    }
}
