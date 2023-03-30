using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService UserService;
    public UsersController(IUserService UserService)
    {
        this.UserService = UserService;
    }

    [HttpGet("")]
    public IEnumerable<User> GetAllProperties()
    {
        return UserService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        User? User = UserService.GetOne(id);
        if (User == null) return NotFound();
        return User;
    }

    [HttpPost("")]
    public User CreateUser(User User)
    {
        return UserService.Create(User);
    }

    [HttpPut("")]
    public ActionResult<User> UpdateUser(User User)
    {
        User? UserUpdated = UserService.Update(User);
        if (UserUpdated == null) return NotFound();
        return UserUpdated;
    }

    [HttpDelete("{id}")]
    public ActionResult<User> DeleteUser(int id)
    {
        User? User = UserService.Delete(id);
        if (User == null) return NotFound();
        return User;
    }
}
