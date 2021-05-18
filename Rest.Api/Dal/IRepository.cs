using Rest.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Dal
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task<int> Delete(int id);
        Task<int> Update(TEntity entity);
    }
}
