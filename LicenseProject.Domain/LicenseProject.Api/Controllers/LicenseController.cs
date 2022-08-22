using AutoMapper;
using LicenseProject.Api.ViewModels;
using LicenseProject.Domain.Models;
using LicenseProject.Infrastructure;
using LicenseProject.Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;
using Portable.Licensing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LicenseProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly ILicensesRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public LicenseController(ILicensesRepository repository, IProductRepository productRepository, IClientRepository clientRepository, IMapper mapper)
        {
            _repository = repository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        // GET: api/<LicenseController>
        [HttpGet]
        public IActionResult Get()
        {
            var license = _repository.ReturnAll();
            var licenseDTO = _mapper.Map<IEnumerable<LicenseDTO>>(license);
            return Ok(licenseDTO);
        }

        // GET api/<LicenseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var license = _repository.ReturnById(id);
            var licenseDTO = _mapper.Map<LicenseDTO>(license);
            return Ok(licenseDTO);
        }

        // POST api/<LicenseController>
        [HttpPost]
        public void GenerateLicense([FromBody] LicenseViewModel license)
        {
            var client = _clientRepository.ReturnById(license.ClientId);
            var product = _productRepository.ReturnById(license.ProductId);
            var licenseToAdd = new Licenses
            {
                //Id=Guid.NewGuid(),
                LicenseType = license.LicenseType,
                Expiration = license.Expiration,
                Product = product,
                Client = client
            };

            if (licenseToAdd.LicenseType == "Perpetual")
            {
                licenseToAdd.Expiration = DateTime.Now.AddYears(1000);

                var licenseToCreate = License.New()
               .WithUniqueIdentifier(licenseToAdd.Id)
               .LicensedTo(licenseToAdd.Client.Name, licenseToAdd.Client.Email)
               .CreateAndSignWithPrivateKey(licenseToAdd.Product.EncryptedPrivateKey, licenseToAdd.Product.PassPhase);

                licenseToAdd.LicenseContent = licenseToCreate.ToString();
            }
            else if (licenseToAdd.LicenseType == "Standard")
            {
                var licenseToCreate = License.New()
               .WithUniqueIdentifier(licenseToAdd.Id)
               .ExpiresAt(licenseToAdd.Expiration)
               .LicensedTo(licenseToAdd.Client.Name, licenseToAdd.Client.Email)
               .CreateAndSignWithPrivateKey(licenseToAdd.Product.EncryptedPrivateKey, licenseToAdd.Product.PassPhase);

                licenseToAdd.LicenseContent = licenseToCreate.ToString();
            }

            _repository.Create(licenseToAdd);
        }

        //// PUT api/<LicenseController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<LicenseController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var licenseToDetele = _repository.ReturnById(id);
            _repository.Delete(licenseToDetele);
        }
    }
}
