using MessengerApp.DALL;
using MessengerApp.Model;
using MessengerApp.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessengerApp.WebApi.Controllers;

[Route("messenger-api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly MessengerDbContext _dbContext;
    private readonly HashHelper _hashHelper;
    private readonly LoginAndPasswordValidation _validation;

    public UserController(MessengerDbContextFactory dbContextFactory, HashHelper hashHelper, LoginAndPasswordValidation validation)
    {
        _dbContext = dbContextFactory.CreateDbContext();
        _hashHelper = hashHelper;
        _validation = validation;
       
        _dbContext.Users.Load();
        _dbContext.Persons.Load();

    }

    [HttpGet("authorize-user/{login}/{password}")]
    public async Task<IActionResult> AuthorizeUser(string login, string password)
    { 
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);

        if (user == null)
            return NotFound($"{login} was not found.");

        if (_hashHelper.ConvertStringToHash(password) != user.Password)
            return BadRequest($"{password} is invalid.");
        return Ok(user);
    }

    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUserAsync([FromBody] User newUser)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == newUser.Login);
        if (user != null)
            return Conflict($"{newUser.Login} is exist.");

        if (!_validation.CheckLogin(newUser.Login) && !_validation.CheckPassword(newUser.Password))
            return BadRequest($"Login:{newUser.Login} or password:{newUser.Password} is not valid!");

        var hashPassword = _hashHelper.ConvertStringToHash(newUser.Password);
        newUser.Password = hashPassword;
        await _dbContext.Users.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();
        return Ok(user);
    }
}
