using Dapper;
using Microsoft.Data.SqlClient;
using Rest.Api.Dtos;
using Rest.Api.Entities;
using Rest.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Dal.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<Category> Add(Category entity)
        {
            var sql = "INSERT INTO Categories (Name) OUTPUT INSERTED.* Values (@Name);";

            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {
                connection.Open();
                var result = await connection.QuerySingleAsync<Category>(sql, entity);

                return result;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Categories WHERE Id = @Id;";
            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });

                return result;
            }
        }

        public async Task<Category> Get(int id)
        {
            var sql = "SELECT * FROM Categories WHERE Id = @Id;";
            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Category>(sql, new { Id = id });

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var sql = "SELECT * FROM Categories;";
            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Category>(sql);

                return result;
            }
        }

        public Task<IEnumerable<Category>> GetAllWithProducts()
        {
            var sql = "SELECT Categories.Name,Products.Name FROM Categories Join Products on Categories.Id=Products.CategoryId;";
            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {
                connection.Open();
                var result = connection.Query<Category, List<Product>, Category>(sql,
                    (category, products) =>
                    {

                        category.Products = products;
                        return category;
                    }, splitOn: "CategoryId,Name"


                ).ToList();

                return null;
            }
            return null;
        }

        public async Task<int> Update(Category entity)
        {
            var sql = "UPDATE Categories SET Name = @Name WHERE Id = @Id;";
            using (var connection = new SqlConnection(ConnectionString.sqlConnectionString))
            {

                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);

                return result;
            }
        }
    }
}
