using LicenseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LicenseProject.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly LicenseProjectContext _context;

        public ProductRepository(LicenseProjectContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product ReturnById(Guid id)
        {
            var productToReturn = _context.Products.Where(x => x.Id == id).Include(x => x.Licenses).FirstOrDefault();
            if (productToReturn == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            return productToReturn;
        }
        public IEnumerable<Product> ReturnAll()
        {
            return _context.Products.Include(x => x.Licenses).ToList();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
