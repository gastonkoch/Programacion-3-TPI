using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderNotificationService //: IOrderNotificationService
    {
        private readonly IOrderNotificationRepository _orderNotificationService;

        public OrderNotificationService(IOrderNotificationRepository orderNotificationService)
        {
            _orderNotificationService = orderNotificationService;
        }

        //public OrderNotificationDto? GetOrderNotificationById(int id)
        //{
        //    //OrderNotificationDto orderNotificationDto = OrderNotificationDto.ToDto(_orderNotificationService.GetByIdAsync(id).Result ?? throw new Exception("No se encontro la notificacion"));
        //    //return orderNotificationDto;
        //}

        //public OrderNotificationDto CreateOrderNotification(OrderNotificationCreateRequest dto)
        //{
        //    return OrderNotificationDto.ToDto(_orderNotificationService.AddAsync(OrderNotificationCreateRequest.ToEntity(dto)).Result);

    }

}
