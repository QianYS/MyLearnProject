using MyProject.Infrastructure.Core;
using MyProject.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyProject.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, Guid, DomainContext>, IOrderRepository
    {
        private readonly DomainContext _context;

        public OrderRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        public List<Order> GetOrderList()
        {
            var query = from a in _context.Orders
                              select a;
            return query.Skip(0).Take(10).ToList();
        }
    }
}
