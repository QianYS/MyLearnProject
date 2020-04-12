using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Infrastructure.Repositories;
using MyProject.Domain.OrderAggregate;

namespace MyProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    /// APIController 主要职责
    /// 1.负责了对前端用户的输入输出定义
    /// 2.负责了身份认证，授权，url定义
    /// 3.不负责业务逻辑的承载
    public class OrderController : ControllerBase
    {
        public IOrderRepository _orderRepository { get; set; }

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task CreateOrUpdate(OrderClass orderclass)
        {
            if (orderclass.Id != Guid.Empty)
            {
                Order order = new Order(orderclass.Id, "xiugai", orderclass.userName, orderclass.itemCount, new Address("", "", ""));
                await _orderRepository.UpdateAsync(order);
            }
            else
            {
                Order order = new Order("xinzeng", orderclass.userName, orderclass.itemCount, new Address("", "", ""));
                await _orderRepository.AddAsync(order);
            }
        }

        public class OrderClass
        {
            public Guid Id { get; set; } = Guid.Empty;
            public string userName { get; set; }
            public int itemCount { get; set; }
        }

        [HttpGet]
        public async Task<List<Order>> GetOrderList()
        {
            return _orderRepository.GetOrderList();
        }

        [HttpDelete]
        public async Task DeleteStudent(OrderClass orderclass)
        {
            var order = _orderRepository.Get(orderclass.Id);
            if (order != null)
            {
                await _orderRepository.RemoveAsync(order);
            }
            else
            {
                throw new Exception("对应数据丢失");
            }
        }
    }
}