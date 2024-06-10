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
    public interface IOrderService
    {
        //Lo Order en un futuro van a ser OrderDto todavia no dimos por que
        //ICollection<Order> GetAll();
        OrderDto GetOrderById(int id);
        OrderDto CreateOrder(OrderCreateRequest order); // Create

        ////Order AddOrderProduct(Product product);
        //void DeleteOrder(int id);
        //void UpdateOrder(int id, OrderDto order);
        //int CheckStock(int OrderId,int ProductId);
        //bool FinishOrder(int id);
    }
}
