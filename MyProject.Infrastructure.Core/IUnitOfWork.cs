using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Core
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 返回影响的数据条数
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 返回保存是否成功
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
