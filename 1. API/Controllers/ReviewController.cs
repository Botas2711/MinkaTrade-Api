using _1._API.Request;
using _1._API.Response;
using _2._Domain.Reviews;
using _3._Data.Model;
using _3._Data.Reviews;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IReviewData _reviewData;
        private IReviewDomain _reviewDomain;
        private IMapper _mapper;
        public ReviewController(IReviewData reviewData, IReviewDomain reviewDomain, IMapper mapper)
        {
            _reviewData = reviewData;
            _reviewDomain = reviewDomain;
            _mapper = mapper;
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public async Task<ReviewResponse> Get(int id)
        {
            var review = await _reviewDomain.GetByIdAsync(id);
            var response = _mapper.Map<Review, ReviewResponse>(review);
            return response;
        }

        // GET: api/<ReviewController>/client/5
        [HttpGet("client/{clientId}")]
        public async Task<List<ReviewResponse>> GetByClientId(int clientId)
        {
            var reviews = await _reviewDomain.GetAllByClientIdAsync(clientId);
            var response = _mapper.Map<List<Review>, List<ReviewResponse>>(reviews);
            return response;
        }

        // GET: api/<ReviewController>/orderDesc/5
        [HttpGet("orderDesc/{clientId}")]
        public async Task<List<ReviewResponse>> GetAllOrderByRateDesc(int clientId)
        {
            var reviews = await _reviewDomain.GetAllOrderByRateDescAsync(clientId);
            var response = _mapper.Map<List<Review>, List<ReviewResponse>>(reviews);
            return response;
        }

        // GET: api/<ReviewController>/orderAsc/5
        [HttpGet("orderAsc/{clientId}")]
        public async Task<List<ReviewResponse>> GetAllOrderByRateAsc(int clientId)
        {
            var reviews = await _reviewDomain.GetAllOrderByRateAscAsync(clientId);
            var response = _mapper.Map<List<Review>, List<ReviewResponse>>(reviews);
            return response;
        }

        // POST api/<ReviewController>
        [HttpPost]
        public async Task<IActionResult> Review([FromBody] ReviewRequest request)
        {
            if (ModelState.IsValid)
            {
                var review = _mapper.Map<ReviewRequest, Review>(request);
                var result = await _reviewDomain.CreateAsync(review);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ReviewRequest request)
        {
            if (ModelState.IsValid)
            {
                var review = _mapper.Map<ReviewRequest, Review>(request);
                var result = await _reviewDomain.UpdateAsync(review, id);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reviewDomain.DeleteAsync(id);
            return Ok(result);
        }
    }
}
