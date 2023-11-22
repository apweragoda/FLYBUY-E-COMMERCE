using System.Collections.Generic;
using ShippingService.Dtos;
using ShippingService.Models;

namespace ShippingService.Data
{
    public interface IShippingRepo
    {
        IEnumerable<Shipping> GetAllShippingInfo();
        void CreateShippingInfo(Shipping shipping);
        bool SaveChanges();

    }
}