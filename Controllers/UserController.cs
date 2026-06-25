using Microsoft.AspNetCore.Mvc;
using TeamHub.Models;

namespace TeamHub.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = new User
        {
            Id = id,
            Name = "Rayan",
            Email = "rayan@test.com"
        };

        return Ok(user);
    }
}