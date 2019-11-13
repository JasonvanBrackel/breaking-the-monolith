using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoreHumanSoftware.Chat.API.Repositories;

namespace MoreHumanSoftware.Chat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messages;
        private readonly IMessageFactory _factory;

        // GET: api/Messages
        public MessagesController(IMessageRepository messages, IMessageFactory factory)
        {
            _messages = messages;
            _factory = factory;
        }

        [HttpGet]
        public IEnumerable<Message> GetMessages()
        {
            return _messages.List();
        }

        // POST: api/Messages
        [HttpPost]
        public void ReceiveMessage([FromBody] ReceivedMessage message)
        {
            var storedMessage = _factory.Create(message);
            _messages.StoreMessage(storedMessage);
        }
    }
}
