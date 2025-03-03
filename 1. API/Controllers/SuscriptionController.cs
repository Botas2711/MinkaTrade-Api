using _1._API.Filter;
using _1._API.Request;
using _1._API.Response;
using _2._Domain.Reviews;
using _2._Domain.Suscriptions;
using _3._Data.Model;
using _3._Data.Reviews;
using _3._Data.Suscriptions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuscriptionController : ControllerBase
    {
        private ISuscriptionData _suscriptionData;
        private ISuscriptionDomain _suscriptionDomain;
        private IMapper _mapper;
        public SuscriptionController(ISuscriptionData suscriptionData, ISuscriptionDomain suscriptionDomain, IMapper mapper)
        {
            _suscriptionData = suscriptionData;
            _suscriptionDomain = suscriptionDomain;
            _mapper = mapper;
        }

        // GET: api/<SuscriptionController>
        /// <summary>
        /// Get al suscriptions from a client
        /// </summary>
        [HttpGet("client/{clientId}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<List<SuscriptionResponse>> GetAllByClientId(int clientId)
        {
            var suscriptions = await _suscriptionDomain.GetAllByClientIdAsync(clientId);
            var response = _mapper.Map<List<Suscription>, List<SuscriptionResponse>>(suscriptions);
            return response;
        }

        // GET api/<SuscriptionController>/5
        /// <summary>
        /// Get a suscription with a filter of its id
        /// </summary>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<SuscriptionResponse> Get(int id)
        {
            var suscription = await _suscriptionDomain.GetByIdAsync(id);
            var response = _mapper.Map<Suscription, SuscriptionResponse>(suscription);
            return response;
        }

        // POST api/<SuscriptionController>
        /// <summary>
        /// Resgiter a suscription of a client
        /// </summary>
        [HttpPost]
        [Authorize("admin,user")]
        public async Task<IActionResult> Post([FromBody] SuscriptionRequest request)
        {
            if (ModelState.IsValid)
            {
                var review = _mapper.Map<SuscriptionRequest, Suscription>(request);
                var result = await _suscriptionDomain.CreateAsync(review);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
