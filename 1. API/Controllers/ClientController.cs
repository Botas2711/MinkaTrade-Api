﻿using _1._API.Filter;
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
        /// <summary>
        /// Get all clients without filters
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        [Authorize("admin")]
        public async Task<List<ClientResponse>> GetAsync()
        {
            var clients = await _clientData.GetAllAsycnc();
            var response = _mapper.Map<List<Client>, List<ClientResponse>>(clients);
            return response;
        }

        // GET api/<ClientController>/5
        /// <summary>
        /// Get a client with a filter of its id
        /// </summary>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<ClientResponse> Get(int id)
        {
            var client = await _clientDomain.GetByIdAsync(id);
            var response = _mapper.Map<Client, ClientResponse>(client);
            return response;
        }

        // POST api/<ClientController>
        /// <summary>
        /// Register one client 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientRequest request)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<ClientRequest, Client>(request);
                var result = await _clientDomain.CreateAsync(client);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<ClientController>/5
        /// <summary>
        /// Update a client information 
        /// </summary>
        [HttpPut("{id}")]
        [Authorize("user")]
        public async Task<IActionResult> Put(int id, [FromBody] ClientRequest request)
        {
            if (ModelState.IsValid)
            {
                var client = _mapper.Map<ClientRequest, Client>(request);
                var result = await _clientDomain.UpdateAsync(client, id);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<ClientController>/activePremiun/5
        [HttpPut("activePremiun/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> ActivePremiun(int id)
        {
            var result = await _clientDomain.ActivatePremiumAsync(id);
            return Ok(result);
        }
    }
}
