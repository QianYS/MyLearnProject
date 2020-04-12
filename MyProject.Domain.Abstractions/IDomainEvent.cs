using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Domain
{
    public interface IDomainEvent : INotification
    {
    }
}
