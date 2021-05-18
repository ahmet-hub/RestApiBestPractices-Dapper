using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Web.Models
{

    public class Response
    {
        public ProductModel[] Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }

    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
