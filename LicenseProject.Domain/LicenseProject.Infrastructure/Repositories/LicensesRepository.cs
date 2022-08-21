using LicenseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseProject.Infrastructure.Repositories
{
    public class LicensesRepository : ILicensesRepository
    {
        private readonly LicenseProjectContext _context;

        public LicensesRepository(LicenseProjectContext context)
        {
            _context = context;
        }

        public void Create(Licenses license)
        {
            _context.Licenses.Add(license);
            _context.SaveChanges();
        }

        public Licenses ReturnById(Guid id)
        {
            var licenseToReturn = _context.Licenses.Where(x => x.Id == id).Include(x => x.Product).Include(x => x.Client).FirstOrDefault();
            if (licenseToReturn == null)
            {
                throw new KeyNotFoundException("Licence not found");
            }
            return licenseToReturn;
        }
        public IEnumerable<Licenses> ReturnAll()
        {
            return _context.Licenses.Include(x => x.Product).Include(x => x.Client).ToList();
        }

        public void Delete(Licenses licenses)
        {
            _context.Licenses.Remove(licenses);
            _context.SaveChanges();
        }
    }
}
