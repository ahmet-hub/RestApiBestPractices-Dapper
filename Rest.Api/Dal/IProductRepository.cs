using Rest.Api.Dtos;
using Rest.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Dal
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllDetails();
    }
}
