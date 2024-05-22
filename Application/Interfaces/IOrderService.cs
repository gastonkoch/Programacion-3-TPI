using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        //Lo Order en un futuro van a ser OrderDto todavia no dimos por que
        ICollection<Order> GetAll();
        Order GetOrderById(int id);
        Order CreateOrder(OrderDto order); // Create

        //Order AddOrderProduct(Product product);
        void DeleteOrder(int id);
        void UpdateOrder(int id, OrderDto order);
        //int CheckStock(int id);
        //bool FinishOrder(int id);
    }
}
