using MessengerApp.DAL;
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
    
}
