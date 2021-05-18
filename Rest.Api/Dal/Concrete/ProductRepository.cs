using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Rest.Api.Dtos;
using Rest.Api.Entities;
using Rest.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Dal.Concrete
{
    public class ProductRepository : IProductRepository
    {

        public async Task<Product> Add(Product entity)
        {
            var sql = "INSERT INTO Products (Name, Amount, Quantity, CategoryId ) OUTPUT INSERTED.* Values (@Name, @Amount, @Quantity, @CategoryId);";

            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleAsync<Product>(sql, entity);
               
                return result;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id;";
            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });

                return result;
            }
        }

        public async Task<Product> Get(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id;";
            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Product>(sql, new { Id = id });

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var sql = "SELECT * FROM Products;";
            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Product>(sql);

                return result;
            }
        }

        public async Task<IEnumerable<Product>> GetAllDetails()
        {
            var sql = "SELECT p.Name, p.Amount,p.Quantity, c.Name FROM Products p INNER JOIN Categories c on p.CategoryId = c.Id;";
            
            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {
                connection.Open();
                //var result = await connection.QueryAsync<Product>(sql);


                var result = connection.Query<Product, Category, Product>(sql,
                 (products, category) =>
                 {

                     products.Category = category;
                     return products;
                 }
                 , splitOn: "CategoryId,Name"


             ).ToList();

                return result;

            }
        }

        public async Task<int> Update(Product entity)
        {
            var sql = "UPDATE Products SET Name = @Name, Amount = @Amount, Quantity = @Quantity WHERE Id = @Id;";
            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                
                return result;
            }
        }
    }
}
