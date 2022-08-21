using LicenseProject.Domain.Models;

namespace LicenseProject.Infrastructure
{
    public interface IClientRepository
    {
        void Create(Client client);
        void Delete(Client client);
        IEnumerable<Client> ReturnAll();
        Client ReturnById(Guid id);
    }
}