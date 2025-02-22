using _1._API.Request;
using _1._API.Response;
using _2._Domain.Messages;
using _3._Data.Messages;
using _3._Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageData _messageData;
        private IMessageDomain _messageDomain;
        private IMapper _mapper;
        public MessageController(IMessageData messageData, IMessageDomain messageDomain, IMapper mapper)
        {
            _messageData = messageData;
            _messageDomain = messageDomain;
            _mapper = mapper;
        }

        // GET: api/<MessageController>
        [HttpGet]
        public async Task<List<MessageReponse>> GetAll()
        {
            var messages = await _messageData.GetAllAsycnc();
            var response = _mapper.Map<List<Message>, List<MessageReponse>>(messages);
            return response;
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public async Task<MessageReponse> Get(int id)
        {
            var message = await _messageDomain.GetByIdAsync(id);
            var response = _mapper.Map<Message, MessageReponse>(message);
            return response;
        }

        // GET api/<MessageController>/chat/5
        [HttpGet("chat/{chatId}")]
        public async Task<List<MessageReponse>> GetAllByChat(int chatId)
        {
            var messages = await _messageDomain.GetAllByChatIdAsync(chatId);
            var response = _mapper.Map<List<Message>, List<MessageReponse>>(messages);
            return response;
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MessageRequest request)
        {
            if (ModelState.IsValid)
            {
                var message = _mapper.Map<MessageRequest, Message>(request);
                var result = await _messageDomain.CreateAsync(message);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MessageRequest request)
        {
            if (ModelState.IsValid)
            {
                var message = _mapper.Map<MessageRequest, Message>(request);
                var result = await _messageDomain.UpdateAsync(message, id);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
