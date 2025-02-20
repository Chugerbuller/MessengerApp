using MessengerApp.DALL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessengerApp.WebApi.Controllers;

[Route("messenger-api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly MessengerDbContext _dbContext;
    public PersonController(MessengerDbContextFactory dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }
    [HttpGet("get-person/{id}")]
    public async Task<IActionResult> GetPersonAsync(Guid id)
    {
        var person = await _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == id);
        if (person == null)
            return NotFound();
        return Ok(person);
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
