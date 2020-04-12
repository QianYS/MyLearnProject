using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.API.IntegrationEvents
{
    public class OrderPaymentSucceededIntegrationEvent
    {
        public OrderPaymentSucceededIntegrationEvent(Guid orderId) => OrderId = orderId;
        public Guid OrderId { get; }
    }
}
