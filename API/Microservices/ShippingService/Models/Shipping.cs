using System.ComponentModel.DataAnnotations;
namespace ShippingService.Models
{
    public class Shipping 
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public float Fee { get; set; }

    }
}