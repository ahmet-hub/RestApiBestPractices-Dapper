using Rest.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Dal
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllWithProducts();
    }
}
