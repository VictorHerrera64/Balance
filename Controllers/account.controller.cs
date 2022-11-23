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
        var account = accountService.get();
        if (account.Any())
        {
            return Ok(account);
        }
        else
        {
            return NotFound("No account available");
        }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetOne(string id)
    {
       var account = await accountService.findOne(id);
        if (account != null)
        {
            return Results.Accepted($"Account information with the ID:   {id}", account);
        }
        else
        {
            return Results.NotFound($"Account not found by ID :  {id}");
        }

    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] AccountModel account)
    {
        await accountService.save(account);
        return Results.Created("account created", account);
    }
     [HttpPut("{id}")]
    public async Task<IResult> Put(string  id, [FromBody] AccountModel account)
    {
       if (await accountService.findOne(id) != null)
        {
            await accountService.update(id, account);
            return Results.Accepted("It has been updated successfully!");
        }
        else
        {
            return Results.NotFound("Account ID does not exist");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
       if (await accountService.findOne(id) != null)
        {
            await accountService.delete(id);
            return Results.Accepted("It has been removed successfully!");
        }
        else
        {
            return Results.NotFound("Account ID does not exist");
        }
    }

}