using _1._API.Request;
using _1._API.Response;
using _2._Domain.Premiuns;
using _3._Data.Model;
using _3._Data.Premiuns;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiunController : ControllerBase
    {
        private IPremiunData _premiunData;
        private IPremiunDomain _premiunDomain;
        private IMapper _mapper;
        public PremiunController(IPremiunData premiunData, IPremiunDomain premiunDomain, IMapper mapper)
        {
            _premiunData = premiunData;
            _premiunDomain = premiunDomain;
            _mapper = mapper;
        }

        // GET api/<PremiunController>/5
        /// <summary>
        /// Get a premiun with a filter of its id
        /// </summary>
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<PremiunResponse> Get(int id)
        {
            var premiun = await _premiunDomain.GetByIdAsync(id);
            var response = _mapper.Map<Premiun, PremiunResponse>(premiun);
            return response;
        }

        // POST api/<PremiunController>
        /// <summary>
        /// Register a premiun
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PremiunRequest request)
        {
            if (ModelState.IsValid)
            {
                var premiun = _mapper.Map<PremiunRequest, Premiun>(request);
                var result = await _premiunDomain.CreateAsync(premiun);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<PremiunController>/5
        /// <summary>
        /// Update a premiun
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PremiunRequest request)
        {
            if (ModelState.IsValid)
            {
                var premiun = _mapper.Map<PremiunRequest, Premiun>(request);
                var result = await _premiunDomain.UpdateAsync(premiun, id);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
