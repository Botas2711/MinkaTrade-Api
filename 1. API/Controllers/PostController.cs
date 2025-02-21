using _1._API.Request;
using _1._API.Response;
using _2._Domain.Posts;
using _3._Data.Model;
using _3._Data.Posts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostData _postData;
        private IPostDomain _postDomain;
        private IMapper _mapper;
        public PostController(IPostData postData, IPostDomain postDomain, IMapper mapper)
        {
            _postData = postData;
            _postDomain = postDomain;
            _mapper = mapper;
        }

        // GET: api/<PostController>
        [HttpGet]
        public async Task<List<PostResponse>> GetAll()
        {
            var posts = await _postData.GetAllAsycnc();
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }


        // GET: api/<PostController>/client/5
        [HttpGet("client/{clientId}")]
        public async Task<List<PostResponse>> GetAllByClientId(int clientId)
        {
            var posts = await _postDomain.GetAllByClientIdAsync(clientId);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET: api/<PostController>/title/5
        [HttpGet("title/{title}")]
        public async Task<List<PostResponse>> GetAllByTitle(string title)
        {
            var posts = await _postDomain.GetAllByTitleIdAsync(title);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET: api/<PostController>/status/5
        [HttpGet("status/{status}")]
        public async Task<List<PostResponse>> GetAllByStatus(bool status)
        {
            var posts = await _postDomain.GetAllByStatusIdAsync(status);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET: api/<PostController>/category/5
        [HttpGet("category/{categoryId}")]
        public async Task<List<PostResponse>> GetAllByCategory(int categoryId)
        {
            var posts = await _postDomain.GetAllByCategoryIdAsync(categoryId);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET: api/<PostController>/rangePrice/initial/5/final/5
        [HttpGet("rangePrice/initial/{initalPrice}/final/{finalPrice}")]
        public async Task<List<PostResponse>> GetAllByRangePrice(decimal initalPrice, decimal finalPrice)
        {
            var posts = await _postDomain.GetAllByRangePriceIdAsync(initalPrice, finalPrice);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET: api/<PostController>/rangeDate/initial/5/final/5
        [HttpGet("rangeDate/initial/{initialDate}/final/{finalDate}")]
        public async Task<List<PostResponse>> GetAllByRangeDate(DateTime initialDate, DateTime finalDate)
        {
            var posts = await _postDomain.GetAllByRangeDateIdAsync(initialDate, finalDate);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public async Task<PostResponse> Get(int id)
        {
            var post = await _postDomain.GetByIdAsync(id);
            var response = _mapper.Map<Post, PostResponse>(post);
            return response;
        }

        // POST api/<PostController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostRequest request)
        {
            if (ModelState.IsValid)
            {
                var post = _mapper.Map<PostRequest, Post>(request);
                var result = await _postDomain.CreateAsync(post);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PostRequest request)
        {
            if (ModelState.IsValid)
            {
                var post = _mapper.Map<PostRequest, Post>(request);
                var result = await _postDomain.UpdateAsync(post, id);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postDomain.DeleteAsync(id);
            return Ok(result);
        }
    }
}
