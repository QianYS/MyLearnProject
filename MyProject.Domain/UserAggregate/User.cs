using MyProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Domain.UserAggregate
{
    public class User : Entity<Guid>, IAggregateRoot
    {
    }
}
