using MessengerApp.DAL;
using MessengerApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessengerApp.WebApi.Controllers;

[Route("messenger-api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly MessengerDbContext _dbContext;

    public ChatController(MessengerDbContextFactory dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }

    [HttpGet("get-chat/{id}")]
    public async Task<IActionResult> GetChatByIdAsync(Guid id)
    {
        var chat = await _dbContext.Chats.FirstOrDefaultAsync(c => c.Id == id);

        if (chat == null)
            return NotFound();

        return Ok(chat);
    }

    [HttpGet("get-all-chats/{userId}")]
    public async Task<IActionResult> GetAllUserChatsAsync(Guid userId)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
            return NotFound();

        var res = await _dbContext.PersonsInChat.Where(pic => pic.PersonId == user.PersonID).ToListAsync();

        if (res == null)
            return NotFound();

        return Ok(res);
    } 

    [HttpPost("update-chat-name/{chatId}/{chatNewName}")]
    public async Task<IActionResult> PostUpdateChatAsync(Guid chatId, string chatNewName)
    {
        var chat = await _dbContext.Chats.FirstOrDefaultAsync(c => c.Id == chatId);

        if (chat == null)
            return NotFound();

        chat.ChatName = chatNewName;

        _dbContext.SaveChanges();

        return Ok(chat);
    }

    [HttpPost("create-chat")]
    public async Task<IActionResult> CreateChatAsync([FromBody] Chat chat)
    {
        await _dbContext.Chats.AddAsync(chat);

        await _dbContext.SaveChangesAsync();

        return Ok(chat);
    }

    [HttpPost("add-person/{chatId}/{personId}")]
    public async Task<IActionResult> AddPersonInChatAsync(Guid chatId, Guid personId)
    {
        var chat = await _dbContext.Chats.FirstOrDefaultAsync(c => c.Id == chatId);

        if (chat == null)
            return NotFound();

        var person = await _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == personId);

        if (person == null)
            return NotFound();

        var chatWithPerson = new PersonsInChat
        {
            Chat = chat,
            Person = person
        };

        await _dbContext.PersonsInChat.AddAsync(chatWithPerson);
        await _dbContext.SaveChangesAsync();

        return Ok(chatWithPerson);
    }
    [HttpDelete("delete-user-from-chat/{chatId}/{personId}")]
    public async Task<IActionResult> DeletePersonFromChatAsync(Guid chatId, Guid personId)
    {
        var chat = await _dbContext.PersonsInChat.FirstOrDefaultAsync(c => c.ChatId == chatId && c.PersonId == personId);

        if (chat == null)
            return NotFound();

        _dbContext.PersonsInChat.Remove(chat);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

}