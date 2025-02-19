using _1._API.Request;
using _1._API.Response;
using _2._Domain.Clients;
using _3._Data.Clients;
using _3._Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientData _clientData;
        private IClientDomain _clientDomain;
        private IMapper _mapper;

        public ClientController (IClientData clientData, IClientDomain clientDomain, IMapper mapper)
        {
            _clientData = clientData;
            _clientDomain = clientDomain;
            _mapper = mapper;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<List<ClientResponse>> GetAsync()
        {
            var clients = await _clientData.GetAllAsycnc();
            var response = _mapper.Map<List<Client>, List<ClientResponse>>(clients);
            return response;
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<Client> Get(int id)
        {
            return await _clientData.GetByIdAsync(id);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientRequest request)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<ClientRequest, Client>(request);
                return Ok(_clientDomain.CreateAsync(client));

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] ClientRequest request)
        {
            Client client = new Client
            {
                first_name = request.first_name,
                last_name = request.last_name,
                birthdate = request.birthdate,
                dni = request.dni,
                email = request.email,
                phone_number = request.phone_number,
                gender = request.gender,
            };
            return true;

            //return _clientDomain.Update(client, id);
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
