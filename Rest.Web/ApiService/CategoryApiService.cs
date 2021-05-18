using Newtonsoft.Json;
using Rest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Web.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Response> GetAllAsync()
        {
            Response  categoryDtos;
            var response = await _httpClient.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                categoryDtos =
                    JsonConvert.DeserializeObject<Response>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDtos = null;
            }

            return categoryDtos;
        }

        public async Task<CategoryModel> AddAsync(CategoryModel categoryModel)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryModel), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("categories", stringContent);
            if (response.IsSuccessStatusCode)
            {
                categoryModel =
                    JsonConvert.DeserializeObject<CategoryModel>(await response.Content.ReadAsStringAsync());
                return categoryModel;
            }
            else
            {
                return null;
            }
        }

        public async Task<CategoryModel> GetAsync(int id)
        {
            var response = await _httpClient.GetAsync($"categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryModel>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Update(CategoryModel categoryModel)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryModel), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("categories", stringContent);

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
            var response = await _httpClient.DeleteAsync($"categories/{id}");

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
