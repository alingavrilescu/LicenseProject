using LicenseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseProject.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly LicenseProjectContext _context;

        public ClientRepository(LicenseProjectContext context)
        {
            _context = context;
        }

        public void Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public Client ReturnById(Guid id)
        {
            var clientToReturn = _context.Clients.Where(x => x.Id == id).Include(x => x.Licenses).FirstOrDefault();
            if (clientToReturn == null)
            {
                throw new KeyNotFoundException("Client not found");
            }
            return clientToReturn;
        }
        public IEnumerable<Client> ReturnAll()
        {
            return _context.Clients.Include(x => x.Licenses).ToList();
        }

        public void Delete(Client client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    }
}
