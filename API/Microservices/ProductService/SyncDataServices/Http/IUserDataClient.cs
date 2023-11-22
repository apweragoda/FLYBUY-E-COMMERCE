using ProductService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.SyncDataServices.Http
{
    public interface IUserDataClient
    {
        Task SendProductsToUser(ProductReadDto product);
    }
}
