using System.ComponentModel.DataAnnotations;
namespace ProductService.Models
{
    public class Product 
    {
        [Key]
        [Required]
        public int Id { get; set; }
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