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

        public ICollection<Customer> GetAllCustomer()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int id) 
        { 
            return _customerRepository.GetCustomerById(id);
        }

        public void Delete(int id)
        {
            var objectDelete = _customerRepository.GetCustomerById(id); // Utilizamos el metodo de get por id para obtener el obj que el usuario desea eliminar
            _customerRepository.Delete(objectDelete);
        }

        public void Update(int id,CustomerDto customer) 
        {
            var objectUpdate = _customerRepository.GetCustomerById(id);
            objectUpdate.Name = customer.Name;
            _customerRepository.Update(objectUpdate);
        }

        public Customer Create(CustomerDto customer)
        {
            var objectNew = new Customer(customer.Id, customer.Name, customer.Password, customer.Email, customer.RegisterDate);
            _customerRepository.Add(objectNew);
            return _customerRepository.GetCustomerById(customer.Id); // Esto no tendria sentido cuando tengamos Base da datos por que el id no llegaria por parametro
        }
    }
}
