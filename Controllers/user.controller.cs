using balance.Models;
using balance.Services;
using Microsoft.AspNetCore.Mvc;
namespace balance.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    IUserService userService;
    public UserController(IUserService service)
    {
        userService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var users = userService.get();
        if (users.Any())
        {
            return Ok(users);
        }
        else
        {
            return NotFound("No users available");
        }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetOne(string id)
    {
        var user = await userService.findOne(id);
        if (user != null)
        {
            return Results.Accepted($"User information with the ID:  {id}", user);
        }
        else
        {
            return Results.NotFound($"User not found by ID :  {id}");
        }


    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] UserModel user)
    {
        if (await userService.findOne(user.User_id) == null)
        {
            await userService.save(user);
            return Results.Created("User created", user);
        }
        else
        {
            return Results.Conflict("User ID already exist, please type another ID again");
        }
    }
    [HttpPut("{id}")]
    public async Task<IResult> Put(string id, [FromBody] UserModel user)
    {
        if (await userService.findOne(id) != null)
        {
            await userService.update(id, user);
            return Results.Accepted("It has been updated successfully!");
        }
        else
        {
            return Results.NotFound("User ID does not exist");
        }

    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
        if (await userService.findOne(id) != null)
        {
            await userService.delete(id);
            return Results.Accepted("It has been removed successfully!");
        }
        else
        {
            return Results.NotFound("User ID does not exist");
        }
    }

}