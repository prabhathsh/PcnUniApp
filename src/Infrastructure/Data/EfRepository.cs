using PcnUniApp.ApplicationCore.Entities;
using PcnUniApp.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PcnUniApp.Infrastructure.Data
{
    // https://github.com/dotnet-architecture/eShopOnWeb
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
    {
        public EfRepository()
        {

        }
        public Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSingleBySpec(ISpecification<T> spec, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ListAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
