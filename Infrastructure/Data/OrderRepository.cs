using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        public ICollection<Order> GetAll()
        {
            return null;
        }

        public Order GetOrderById(int id)
        {
            return null;
        }
        public Order AddOrder(Order order)
        {
            return null;
        }
        //public User AddOrderProduct(User user)

        public void DeleteOrder(Order order)
        {

        }

        public void UpdateOrder(Order order)
        {

        }
        public int CheckStock(Product product)
        {
            return 0;
        }

        public bool FinishOrder()
        {
            return false;
        }

    }
}
