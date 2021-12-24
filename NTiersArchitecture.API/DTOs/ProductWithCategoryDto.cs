using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTiersArchitecture.API.DTOs
{
    public class ProductWithCategoryDto :ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
