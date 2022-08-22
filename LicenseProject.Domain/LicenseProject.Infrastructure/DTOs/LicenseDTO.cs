using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseProject.Infrastructure.DTOs
{
    public class LicenseDTO
    {
        public Guid Id { get; set; }
        public string LicenseContent { get; set; }
        public string LicenseType { get; set; }
        public DateTime Expiration { get; set; }
        public ProductDTO Product { get; set; }
        public ClientDTO Client { get; set; }
    }
}
