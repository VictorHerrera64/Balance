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
        return Ok(userService.get());
    }

    [HttpGet("{id_user}")]
    public async Task<IResult> GetOne(string id_user)
    {
        var user = await userService.findOne(id_user);
        return Results.Accepted($"Usuario encontrado por el :  {id_user}", user);

    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] UserModel user)
    {
        await userService.save(user);
        return Results.Created("User creado", user);
    }
     [HttpPut("{id}")]
    public async Task<IResult> Put(string  id, [FromBody] UserModel user)
    {
       await userService.update(id,user);
       return Results.Accepted("Se ha actualizado con exito!", user);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
       await userService.delete(id);
       return Results.Accepted("Se ha eliminado con exito!", id);
    }

}