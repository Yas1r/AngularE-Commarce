using API.Core.DbModels;
using API.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsycn(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpec(ISpecifications<T> spec);

        Task<IReadOnlyList<T>> ListAsycn(ISpecifications<T> spec);
    }
}
