using MessengerApp.DAL;
using MessengerApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessengerApp.WebApi.Controllers;

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
    public async Task<IActionResult> PostMessageInChatAsync([FromBody] (Chat chat, Message msg) msgInChat)
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
    [HttpGet("get-all-msg/{chatId}")]
    public async Task<IActionResult> GetAllMsgInChatAsync(Guid chatId)
    {
        var chat = await _dbContext.Chats.FirstOrDefaultAsync(c => c.Id == chatId);

        if (chat == null)
            return NotFound();

        var res = await _dbContext.MessagesInChat.Where(ch => ch.ChatId == chatId).ToListAsync();

        if (res == null)
            return NotFound();

        return Ok(res);
    }
}
