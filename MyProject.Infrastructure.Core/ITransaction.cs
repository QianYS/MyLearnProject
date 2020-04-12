using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Core
{
    /// <summary>
    /// 事务管理接口
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// 获取当前事务（方法）
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction GetCurrentTransaction();

        /// <summary>
        /// 判断事务是否开启（属性）
        /// </summary>
        bool HasActiveTransaction { get; }

        /// <summary>
        /// 开启事务（方法）
        /// </summary>
        /// <returns></returns>
        Task<IDbContextTransaction> BeginTransactionAsync();

        /// <summary>
        /// 提交事务（方法）
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task CommitTransactionAsync(IDbContextTransaction transaction);

        /// <summary>
        /// 事务回滚（方法）
        /// </summary>
        void RollbackTransaction();
    }
}
