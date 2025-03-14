﻿using _1._API.Filter;
using _1._API.Request;
using _1._API.Response;
using _2._Domain.Chats;
using _3._Data.Chats;
using _3._Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IChatData _chatData;
        private IChatDomain _chatDomain;
        private IMapper _mapper;
        public ChatController(IChatData chatData, IChatDomain chatDomain, IMapper mapper)
        {
            _chatData = chatData;
            _chatDomain = chatDomain;
            _mapper = mapper;
        }

        // GET: api/<ChatController>
        /// <summary>
        /// Get all chats without filters
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        [Authorize("admin")]
        public async Task<List<ChatResponse>> GetAll()
        {
            var chats = await _chatData.GetAllAsycnc();
            var response = _mapper.Map<List<Chat>, List<ChatResponse>>(chats);
            return response;
        }

        // GET: api/<ReviewController>/client/5
        /// <summary>
        /// Get all chats from a client
        /// </summary>
        [HttpGet("client/{clientId}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<List<ChatResponse>> GetAllByClientId(int clientId)
        {
            var chats = await _chatDomain.GetAllByClientIdAsync(clientId);
            var response = _mapper.Map<List<Chat>, List<ChatResponse>>(chats);
            return response;
        }

        // GET api/<ChatController>/5
        /// <summary>
        /// Get a chat with a filter of its id
        /// </summary>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [Authorize("admin,user")]
        public async Task<ChatResponse> Get(int id)
        {
            var chat = await _chatDomain.GetByIdAsync(id);
            var response = _mapper.Map<Chat, ChatResponse>(chat);
            return response;
        }

        // POST api/<ChatController>
        /// <summary>
        /// Register a chat
        /// </summary>
        [HttpPost]
        [Authorize("user")]
        public async Task<IActionResult> Post([FromBody] ChatRequest request)
        {
            if (ModelState.IsValid)
            {
                var chat = _mapper.Map<ChatRequest, Chat>(request);
                var result = await _chatDomain.CreateAsync(chat);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
