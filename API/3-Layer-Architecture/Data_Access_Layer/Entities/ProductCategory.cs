using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data_Access_Layer.Repository.Entities
{
    public class ProductCategories
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Category")]
        public string ProductCategory { get; set; }

    }
}
