using LicenseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseProject.Infrastructure
{
    public class LicenseProjectContext : DbContext
    {
        public LicenseProjectContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Licenses> Licenses { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
