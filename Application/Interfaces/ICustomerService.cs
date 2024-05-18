using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        ICollection<Customer> GetAllCustomer(); //GetAll
        Customer GetCustomerById(int id); 
        void Delete(int id);
        void Update(int id, CustomerDto customer);
        Customer Create(CustomerDto customer); // Add

        //Customer ChangePassword(int id,CustomerChangePassword customerNewPassword);
    }
}
