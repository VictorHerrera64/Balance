using balance.Models;
using balance.Services;
using Microsoft.AspNetCore.Mvc;
namespace balance.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    IAccountService accountService;
    public AccountController(IAccountService service)
    {
       accountService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(accountService.get());
    }

    [HttpGet("{id_account}")]
    public async Task<IResult> GetOne(string id_account)
    {
        var bank = await accountService.findOne(id_account);
        return Results.Accepted($"account encontrado por el id :  {id_account}", bank);

    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] AccountModel account)
    {
        await accountService.save(account);
        return Results.Created("account creado", account);
    }
     [HttpPut("{id}")]
    public async Task<IResult> Put(string  id, [FromBody] AccountModel account)
    {
       await accountService.update(id,account);
       return Results.Accepted("Se ha actualizado con exito!", account);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
       await accountService.delete(id);
       return Results.Accepted("Se ha eliminado con exito!", id);
    }

}