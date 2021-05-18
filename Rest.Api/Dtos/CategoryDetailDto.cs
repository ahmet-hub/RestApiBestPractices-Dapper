using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Dtos
{
    public class CategoryDetailDto
    {
        public string Name { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}
