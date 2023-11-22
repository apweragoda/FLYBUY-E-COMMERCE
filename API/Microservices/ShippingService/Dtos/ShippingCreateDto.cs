using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Dtos
{
    public class ShippingCreateDto
    {

        [Required]
        public string Province { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public float Fee { get; set; }
    }
}
