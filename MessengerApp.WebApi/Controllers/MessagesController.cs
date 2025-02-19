using MessengerApp.DALL;
using MessengerApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessengerApp.WebApi.Controllers
{
    [Route("messenger-api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessengerDbContext _dbContext;

        public MessagesController(MessengerDbContextFactory dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }
        [HttpPost("add-message-in-chat")]
        public async Task<IActionResult> PostMessageInChat([FromBody] (Chat chat, Message msg) msgInChat)
        {
            var chat = await _dbContext.Chats.FirstOrDefaultAsync(c => c.Id == msgInChat.chat.Id);

            if (chat == null)
                return NotFound($"{msgInChat.chat.ChatName} was not found.");

            await _dbContext.Message.AddAsync(msgInChat.msg);

            var temp = new MessagesInChat
            {
                Chat = chat,
                Message = msgInChat.msg
            };

            await _dbContext.MessagesInChat.AddAsync(temp);

            await _dbContext.SaveChangesAsync();

            return Ok(temp);
        }
    }
}
