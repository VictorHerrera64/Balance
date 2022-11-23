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
            return NotFound(" No hay usuarios disponibles");
        }
    }

    [HttpGet("{id_user}")]
    public async Task<IResult> GetOne(string id_user)
    {
        var user = await userService.findOne(id_user);
        if (user != null)
        {
            return Results.Accepted($"Usuario encontrado por el id :  {id_user}", user);
        }
        else
        {
            return Results.NotFound($"Usuario  no encontrado por el id :  {id_user}");
        }


    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] UserModel user)
    {
        await userService.save(user);
        return Results.Created("User creado", user);
    }
    [HttpPut("{id}")]
    public async Task<IResult> Put(string id, [FromBody] UserModel user)
    {
        if (await userService.findOne(id) != null)
        {
            await userService.update(id, user);
            return Results.Accepted("Se ha actualizado con exito!");
        }
        else
        {
            return Results.NotFound("El ID de usuario no existe");
        }

    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
        if (await userService.findOne(id) != null)
        {
        await userService.delete(id);
        return Results.Accepted("Se ha eliminado con exito!", id);
        }else{
           return Results.NotFound("El ID de usuario no existe"); 
        }
    }

}