using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Models;

namespace ProductService.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext context;

        public ProductRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            context.Products.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return context.Products.
                Where(p => p.Category == category).
                ToList();
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

    }
}
