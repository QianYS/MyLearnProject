﻿using MyProject.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Domain.Events
{
    public class OrderCreatedDomainEvent : IDomainEvent
    {
        public Order Order { get; private set; }
        public OrderCreatedDomainEvent(Order order)
        {
            this.Order = order;
        }
    }
}
