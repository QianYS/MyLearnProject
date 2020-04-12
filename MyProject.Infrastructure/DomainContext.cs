using DotNetCore.CAP;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.OrderAggregate;
using MyProject.Domain.UserAggregate;
using MyProject.Infrastructure.Core;
using MyProject.Infrastructure.EntityConfigurations;
using System;

namespace MyProject.Infrastructure
{
    public class DomainContext : EFContext
    {
        //public DomainContext(DbContextOptions options, IMediator mediator, ICapPublisher capBus) : base(options, mediator, capBus)
        //{

        //}

        public DomainContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
