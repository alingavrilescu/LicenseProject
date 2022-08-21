using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseProject.Domain.Models
{
    public class Licenses : Entity
    {
        public string LicenseContent { get; set; }
        public string LicenseType { get; set; }
        public DateTime Expiration { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
    }
}
