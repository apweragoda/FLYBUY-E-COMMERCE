using System.Collections.Generic;
using ProductService.Models;

namespace ProductService.Data
{
    public interface IProductRepo
    {
        bool SaveChanges();
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        IEnumerable<Product> GetProductsByCategory(string category);
        void CreateProduct(Product product);
         
    }
}