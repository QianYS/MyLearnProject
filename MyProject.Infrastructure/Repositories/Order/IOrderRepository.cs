using MyProject.Domain.OrderAggregate;
using MyProject.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        List<Order> GetOrderList();
    }
}
