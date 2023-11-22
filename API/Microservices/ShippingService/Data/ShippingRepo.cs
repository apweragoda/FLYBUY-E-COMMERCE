using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.Dtos;
using ShippingService.Models;

namespace ShippingService.Data
{
    public class ShippingRepo : IShippingRepo
    {
        private readonly AppDbContext context;

        public ShippingRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateShippingInfo(Shipping shipping)
        {
            if (shipping == null)
                throw new ArgumentNullException(nameof(shipping));

            context.Shippings.Add(shipping);

        }

        public IEnumerable<Shipping> GetAllShippingInfo()
        {
            return context.Shippings.ToList();
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

    }
}
