using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _customerRepository.GetAll();
        }

        public int AddUser(CustomerDto customer)
        {
            Customer newCustomer = new Customer()
                {
                    Name = customer.Name,
                    Password = customer.Password,
                    Email = customer.Email,
                    RegisterDate = customer.RegisterDate
            };
            return _customerRepository.AddUser(newCustomer);
        }
    }
}
