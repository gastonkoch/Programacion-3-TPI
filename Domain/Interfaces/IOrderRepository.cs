using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        //ICollection<Order> GetAll();
        //Order GetOrderById(int id);
        //Order AddOrder(Order order); // Create
        ////Order AddOrderProduct(Product product);
        //void DeleteOrder(Order order);
        //void UpdateOrder(Order order);
        ////int CheckStock(Product product);
        ////bool FinishOrder(Order order);
    }
}
