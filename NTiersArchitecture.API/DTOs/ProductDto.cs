using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NTiersArchitecture.API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,double.MaxValue)]
        public decimal Price { get; set; }
        [Range(1,int.MaxValue)]
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
