using _1._API.Request;
using _1._API.Response;
using _2._Domain.PostImages;
using _3._Data.Model;
using _3._Data.PostImages;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostImageController : ControllerBase
    {
        private IPostImageData _postImageData;
        private IPostImageDomain _postImageDomain;
        private IMapper _mapper;
        public PostImageController(IPostImageData postImageData, IPostImageDomain postImageDomain, IMapper mapper)
        {
            _postImageData = postImageData;
            _postImageDomain = postImageDomain;
            _mapper = mapper;
        }

        // GET: api/<PostImageController>/post/5
        /// <summary>
        /// Get all post images from a post
        /// </summary>
        [HttpGet("post/{posId}")]
        [Produces("application/json")]
        public async Task<List<PostImageResponse>> GetAll(int posId)
        {
            var postImages = await _postImageDomain.GetAllByPostIdAsync(posId);
            var response = _mapper.Map<List<PostImage>, List<PostImageResponse>>(postImages);
            return response;
        }

        // GET api/<PostImageController>/5
        /// <summary>
        /// Get one post image with a filter of its id
        /// </summary>
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<PostImageResponse> Get(int id)
        {
            var postImage = await _postImageDomain.GetByIdAsync(id);
            var response = _mapper.Map<PostImage, PostImageResponse>(postImage);
            return response;
        }

        // POST api/<PostImageController>
        /// <summary>
        /// Register a post image
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PostImageRequest request)
        {
            if (ModelState.IsValid)
            {
                var postImage = _mapper.Map<PostImageRequest, PostImage>(request);
                var result = await _postImageDomain.CreateAsync(postImage);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<PostImageController>/5
        /// <summary>
        /// Update a post image
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] PostImageRequest request)
        {
            if (ModelState.IsValid)
            {
                var postImage = _mapper.Map<PostImageRequest, PostImage>(request);
                var result = await _postImageDomain.UpdateAsync(postImage, id);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/<PostImageController>/5
        /// <summary>
        /// Delete a post image
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postImageDomain.DeleteAsync(id);
            return Ok(result);
        }
    }
}
