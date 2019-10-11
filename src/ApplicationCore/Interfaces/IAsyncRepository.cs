using PcnUniApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PcnUniApp.ApplicationCore.Interfaces
{
    // https://github.com/dotnet-architecture/eShopOnWeb
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<T>> ListAllAsync(CancellationToken cancellationToken);
        Task<List<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        Task<T> GetSingleBySpec(ISpecification<T> spec, CancellationToken cancellationToken);
        Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken);
    }
}
