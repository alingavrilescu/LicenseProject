using AutoMapper;
using LicenseProject.Infrastructure.DTOs;
using LicenseProject.Api.ViewModels;
using LicenseProject.Domain.Models;
using LicenseProject.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LicenseProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            var product = _repository.ReturnAll();
            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(product);
            return Ok(productDTO);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var product = _repository.ReturnById(id);
            var productDTO = _mapper.Map<ProductDTO>(product);
            return Ok(productDTO);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductViewModel product)
        {
            //Generate KeyPair
            var keyGenerator = Portable.Licensing.Security.Cryptography.KeyGenerator.Create();
            var keyPair = keyGenerator.GenerateKeyPair();
            var privateKey = keyPair.ToEncryptedPrivateKeyString(product.PassPhase);
            var publicKey = keyPair.ToPublicKeyString();

            var productToAdd = new Product
            {
                Name = product.Name,
                Description = product.Description,
                EncryptedPrivateKey=privateKey,
                PublicKey=publicKey,
                PassPhase=product.PassPhase

            };

            _repository.Create(productToAdd);
        }

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var productToDetele = _repository.ReturnById(id);
            _repository.Delete(productToDetele);
        }
    }
}
