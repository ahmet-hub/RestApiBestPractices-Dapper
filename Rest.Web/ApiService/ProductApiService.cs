using Newtonsoft.Json;
using Rest.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Web.ApiService
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> GetAllAsync()
        {
          
            Response productDtos;

            var response = await _httpClient.GetAsync("products");
            if (response.IsSuccessStatusCode)
            {

                productDtos =
                    JsonConvert.DeserializeObject<Response>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                productDtos = null;
            }
            return productDtos;

        }

        public async Task<ProductModel> AddAsync(ProductModel productModel)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productModel), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("products", stringContent);

            if (response.IsSuccessStatusCode)
            {
                productModel =
                    JsonConvert.DeserializeObject<ProductModel>(await response.Content.ReadAsStringAsync());
                return productModel;
            }
            else
            {
                return null;
            }
        }

        public async Task<ProductModel> GetAsync(int id)
        {
            var response = await _httpClient.GetAsync($"products/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductModel>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Update(ProductModel productModel)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productModel), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("products", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
