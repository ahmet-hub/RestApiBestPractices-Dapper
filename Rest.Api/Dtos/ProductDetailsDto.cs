using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Dtos
{
    public class ProductDetailsDto
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public CategoryDto Category { get; set; }
    }
}
