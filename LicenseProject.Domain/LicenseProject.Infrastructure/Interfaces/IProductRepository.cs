using LicenseProject.Domain.Models;

namespace LicenseProject.Infrastructure
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Delete(Product product);
        IEnumerable<Product> ReturnAll();
        Product ReturnById(Guid id);
    }
}