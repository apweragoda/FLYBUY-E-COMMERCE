using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Linq;

namespace Business_Logic_Layer.Models
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PorductId { get; set; }

        public Order Order { get; set; }
        public Product Products { get; set; }
    }
}
