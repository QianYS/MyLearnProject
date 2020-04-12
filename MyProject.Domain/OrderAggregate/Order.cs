using MyProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Domain.OrderAggregate
{
    /// <summary>
    /// 备注：
    /// 将领域模型字段的修改设置为私有
    /// 使用构造函数表示对象的创建
    /// 使用具有业务含义的动作来操作模型字段
    /// 领域模型负责对自己数据的处理
    /// 领域服务或命令处理者负责调用领域模型业务动作
    /// </summary>
    public class Order : Entity<Guid>, IAggregateRoot
    {
        public string UserId { get; private set; }

        public string UserName { get; private set; }

        public Address Address { get; private set; }

        public int ItemCount { get; private set; }

        protected Order()
        { }

        public Order(Guid id, string userId, string userName, int itemCount, Address address)
        {
            this.Id = id;
            this.UserId = userId;
            this.UserName = userName;
            this.Address = address;
            this.ItemCount = itemCount;

            //this.AddDomainEvent(new OrderCreatedDomainEvent(this));
        }

        public Order(string userId, string userName, int itemCount, Address address)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.Address = address;
            this.ItemCount = itemCount;

            //this.AddDomainEvent(new OrderCreatedDomainEvent(this));
        }


        public void ChangeAddress(Address address)
        {
            this.Address = address;
            //this.AddDomainEvent(new OrderAddressChangedDomainEvent(this));
        }



    }
}
