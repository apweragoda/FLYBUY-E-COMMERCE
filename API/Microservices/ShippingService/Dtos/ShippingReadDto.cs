using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Dtos
{
    public class ShippingReadDto
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public string Town { get; set; }
        public float Fee { get; set; }
    }
}
