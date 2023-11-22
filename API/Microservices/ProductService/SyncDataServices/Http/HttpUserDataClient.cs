using Microsoft.Extensions.Configuration;
using ProductService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductService.SyncDataServices.Http
{
    public class HttpUserDataClient : IUserDataClient
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;

        public HttpUserDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task SendProductsToUser(ProductReadDto product)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                "application/json");

            var response = await httpClient.PostAsync($"{configuration["OrderService"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to OrderService was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to OrderService was NOT OK!");
            }
        }
    }
}
