using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMailService _mailService;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository, IMailService mailService)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mailService = mailService;
        }

        public OrderDto GetOrderById(int id)
        {
            var order = _orderRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontro la orden");
            var customer = _userRepository.GetByIdAsync(order.CustomerId).Result ?? throw new Exception("No se encontro el usuario");
            var seller = _userRepository.GetByIdAsync(order.SellerId).Result ?? throw new Exception("No se encontro el usuario");
            order.Customer = customer;
            order.Seller = seller;
            OrderDto orderDto = OrderDto.ToDto(order);
            return orderDto;
        }

        public OrderDto CreateOrder(OrderCreateRequest order)
        {
            var customer = _userRepository.GetByIdAsync(order.CustomerId).Result ?? throw new Exception("No se encontro el usuario");
            var seller = _userRepository.GetByIdAsync(order.SellerId).Result ?? throw new Exception("No se encontro el usuario");

            List<Product> products = new List<Product>();
            int amountProduct = 0;

            foreach (int productId in order.ProductsInOrderId)
            {
                products.Add(_productRepository.GetByIdAsync(productId).Result ?? throw new Exception("No se encontro el Producto"));
                amountProduct++;
            }

            var newOrder = new Order(customer, seller, products);

            newOrder.AmountProducts = amountProduct;
            newOrder.PaymentMethod = order.PaymentMethod;

            _orderRepository.AddAsync(newOrder).Wait();

            if (_orderRepository.SaveChangesAsync().Result > 0)
                _mailService.Send("Se creó una nueva order",
                    $"Usted tiene una nueva order asignada por parte del comprador: {customer.Name} {customer.LastName}",
                    seller.Email);



            return OrderDto.ToDto(newOrder);

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
