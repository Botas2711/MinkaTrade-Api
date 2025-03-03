using _1._API.Filter;
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
        /// <summary>
        /// Get all Posts without filters
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<List<PostResponse>> GetAll()
        {
            var posts = await _postData.GetAllAsycnc();
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }


        // GET: api/<PostController>/client/5
        /// <summary>
        /// Get all posts from a client
        /// </summary>
        [HttpGet("client/{clientId}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<List<PostResponse>> GetAllByClientId(int clientId)
        {
            var posts = await _postDomain.GetAllByClientIdAsync(clientId);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET: api/<PostController>/title/5
        /// <summary>
        /// Get all posts with a filter title
        /// </summary>
        [HttpGet("title/{title}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<List<PostResponse>> GetAllByTitle(string title)
        {
            var posts = await _postDomain.GetAllByTitleAsync(title);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET: api/<PostController>/status/5
        /// <summary>
        /// Get all posts with a filter status
        /// </summary>
        [HttpGet("status/{status}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<List<PostResponse>> GetAllByStatus(bool status)
        {
            var posts = await _postDomain.GetAllByStatusAsync(status);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET: api/<PostController>/category/5
        /// <summary>
        /// Get all posts with a filter category
        /// </summary>
        [HttpGet("category/{categoryId}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<List<PostResponse>> GetAllByCategory(int categoryId)
        {
            var posts = await _postDomain.GetAllByCategoryIdAsync(categoryId);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET: api/<PostController>/rangePrice/initial/5/final/5
        /// <summary>
        /// Get all posts with in a price range
        /// </summary>
        [HttpGet("rangePrice/initial/{initalPrice}/final/{finalPrice}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<List<PostResponse>> GetAllByRangePrice(decimal initalPrice, decimal finalPrice)
        {
            var posts = await _postDomain.GetAllByRangePriceAsync(initalPrice, finalPrice);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET: api/<PostController>/rangeDate/initial/5/final/5
        /// <summary>
        /// Get all posts with in a date range
        /// </summary>
        [HttpGet("rangeDate/initial/{initialDate}/final/{finalDate}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<List<PostResponse>> GetAllByRangeDate(DateTime initialDate, DateTime finalDate)
        {
            var posts = await _postDomain.GetAllByRangeDateAsync(initialDate, finalDate);
            var response = _mapper.Map<List<Post>, List<PostResponse>>(posts);
            return response;
        }

        // GET api/<PostController>/5
        /// <summary>
        /// Get one post with a filter of its id
        /// </summary>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<PostResponse> Get(int id)
        {
            var post = await _postDomain.GetByIdAsync(id);
            var response = _mapper.Map<Post, PostResponse>(post);
            return response;
        }

        // POST api/<PostController>
        /// <summary>
        /// Register a post
        /// </summary>
        [HttpPost]
        [Authorize("user")]
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
        /// <summary>
        /// Update a post
        /// </summary>
        [HttpPut("{id}")]
        [Authorize("user")]
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
        /// <summary>
        /// Delete a post
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize("admin,user")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postDomain.DeleteAsync(id);
            return Ok(result);
        }
    }
}
