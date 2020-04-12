using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using MyProject.Infrastructure.Core.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Infrastructure
{
    public class DomainContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<DomainContext, TRequest, TResponse>
    {
        public DomainContextTransactionBehavior(DomainContext dbContext, ICapPublisher capBus, ILogger<DomainContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, capBus, logger)
        {
        }
    }
}
