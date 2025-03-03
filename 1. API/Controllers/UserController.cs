using _1._API.Filter;
using _1._API.Request;
using _1._API.Response;
using _2._Domain.Clients;
using _2._Domain.Users;
using _3._Data.Clients;
using _3._Data.Model;
using _3._Data.Users;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserData _userData;
        private IUserDomain _userDomain;
        private IMapper _mapper;

        public UserController(IUserData userData, IUserDomain userDomain, IMapper mapper)
        {
            _userData = userData;
            _userDomain = userDomain;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        /// <summary>
        /// Get all users without filters
        /// </summary>
        [HttpGet]
        [Authorize("admin")]
        [Produces("application/json")]
        public async Task<List<UserResponse>> GetAll()
        {
            var users = await _userData.GetAllAsycnc();
            var response = _mapper.Map<List<User>, List<UserResponse>>(users);
            return response;
        }

        // POST api/<UserController>/login
        /// <summary>
        /// Login a user
        /// </summary>
        [HttpPost]
        [Route("login")]
        [Produces("application/json")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserLoginRequest, User>(request);
                var result = await _userDomain.LoginAsync(user);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // POST api/<UserController>/signup
        /// <summary>
        /// Create a user
        /// </summary>
        [HttpPost]
        [Route("signup")]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] UserCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserCreateRequest, User>(request);
                var result = await _userDomain.CreateAsync(user);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<UserController>/disable/5
        /// <summary>
        /// Disable a user
        /// </summary>
        [HttpPut("disable/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> Put(int id)
        {
            var result = await _userDomain.DeleteAsync(id);
            return Ok(result);
        }
    }
}
