using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
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

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderDto GetOrderById(int id)
        {
            OrderDto orderDto = OrderDto.ToDto(_orderRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontro la orden"));
            return orderDto;
        }

        public OrderDto CreateOrder(OrderCreateRequest dto)
        {
            return OrderDto.ToDto(_orderRepository.AddAsync(OrderCreateRequest.ToEntity(dto)).Result);

        }

        //private readonly IProductRepository _productRepository;

        //public OrderService(IOrderRepository orderRepository, IProductRepository productRepository = null)
        //{
        //    _orderRepository = orderRepository;
        //    _productRepository = productRepository;
        //}

        //public ICollection<Order> GetAll()
        //{
        //    return _orderRepository.GetAll();
        //}

        //public Order GetOrderById(int id)
        //{
        //    return _orderRepository.GetOrderById(id);
        //}

        //public void DeleteOrder(int id)
        //{
        //    var orderDelete = _orderRepository.GetOrderById(id);
        //    _orderRepository.DeleteOrder(orderDelete);
        //}

        //public void UpdateOrder(int id, OrderDto order)
        //{
        //    var orderUpdate = _orderRepository.GetOrderById(id);
        //    orderUpdate.StatusOrder = order.StatusOrder;
        //    _orderRepository.UpdateOrder(orderUpdate);
        //}

        //public Order CreateOrder(OrderDto order)
        //{

        //    var newOrder = new Order() 
        //    {
        //        Id = order.Id, // borrar
        //        //AmountProducts = order.AmountProducts,
        //        PaymentMethod = order.PaymentMethod,
        //        StatusOrder = order.StatusOrder,
        //        //Customer = customer,
        //        //Seller = seller
        //    };

        //   foreach (var productId in order.ProductsIds)
        //   {
        //       var product = _productRepository.GetProductById(productId);
        //       if (product != null)
        //       {
        //           //newOrder.Products.Add(product);
        //       }
        //   }

        //   //newOrder.AmountProducts = newOrder.Products.Count;


        //    _orderRepository.AddOrder(newOrder);
        //    return _orderRepository.GetOrderById(order.Id);
        //}        
    }
}
