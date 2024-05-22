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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        //public OrderService(IOrderRepository orderRepository)
        //{
        //    _orderRepository = orderRepository;
        //}

        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository = null)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public ICollection<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }
        
        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public void DeleteOrder(int id)
        {
            var orderDelete = _orderRepository.GetOrderById(id);
            _orderRepository.DeleteOrder(orderDelete);
        }

        public void UpdateOrder(int id, OrderDto order)
        {
            var orderUpdate = _orderRepository.GetOrderById(id);
            orderUpdate.StatusOrder = order.StatusOrder;
            _orderRepository.UpdateOrder(orderUpdate);
        }

        public Order CreateOrder(OrderDto order)
        {
            var customer = _userRepository.GetUserById(order.CustomerId);
            var seller = _userRepository.GetUserById(order.SellerId);

            var newOrder = new Order() 
            {
                Id = order.Id, // borrar
                AmountProducts = order.AmountProducts,
                PaymentMethod = order.PaymentMethod,
                StatusOrder = order.StatusOrder,
                Customer = customer,
                Seller = seller
            };
            _orderRepository.AddOrder(newOrder);
            return _orderRepository.GetOrderById(order.Id);
        }

        

    }
}
