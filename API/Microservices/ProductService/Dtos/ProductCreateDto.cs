using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Dtos
{
    public class ProductCreateDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Ratings { get; set; }
    }
}
