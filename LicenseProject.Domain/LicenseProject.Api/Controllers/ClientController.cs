using AutoMapper;
using LicenseProject.Api.ViewModels;
using LicenseProject.Domain.Models;
using LicenseProject.Infrastructure;
using LicenseProject.Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LicenseProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;

        }
        // GET: api/<ClientController>
        [HttpGet]
        public IActionResult Get()
        {
            var client = _clientRepository.ReturnAll();
            var clientDTO = _mapper.Map<IEnumerable<ClientDTO>>(client);
            return Ok(clientDTO);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var client = _clientRepository.ReturnById(id);
            var clientDTO = _mapper.Map<ClientDTO>(client);
            return Ok(clientDTO);
        }

        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromBody] ClientViewModel client)
        {
            var clientToAdd = new Client
            {
                Name = client.Name,
                Email = client.Email
            };
            _clientRepository.Create(clientToAdd);
        }

        //// PUT api/<ClientController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var clientToDelete = _clientRepository.ReturnById(id);
            _clientRepository.Delete(clientToDelete);
        }
    }
}
