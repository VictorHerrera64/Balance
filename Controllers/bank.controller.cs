using balance.Models;
using balance.Services;
using Microsoft.AspNetCore.Mvc;
namespace balance.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BankController : ControllerBase
{
    IBankService bankService;
    public BankController(IBankService service)
    {
        bankService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var bank = bankService.get();
        if (bank.Any())
        {
            return Ok(bank);
        }
        else
        {
            return NotFound("No banks available");
        }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetOne(string id)
    {
        var bank = await bankService.findOne(id);
        if (bank != null)
        {
            return Results.Accepted($"Bank information with the ID:   {id}", bank);
        }
        else
        {
            return Results.NotFound($"Bank not found by ID :  {id}");
        }
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] BankModel bank)
    {
        if (await bankService.findOne(bank.Bank_id) == null)
        {
            await bankService.save(bank);
            return Results.Created("bank created", bank);
        }
        else
        {
            return Results.Conflict("Bank ID already exist, please type another ID again");
        }
    }
    [HttpPut("{id}")]
    public async Task<IResult> Put(string id, [FromBody] BankModel bank)
    {
        if (await bankService.findOne(id) != null)
        {
            await bankService.update(id, bank);
            return Results.Accepted("It has been updated successfully!");
        }
        else
        {
            return Results.NotFound("Bank ID does not exist");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
        if (await bankService.findOne(id) != null)
        {
            await bankService.delete(id);
            return Results.Accepted("It has been removed successfully!");
        }
        else
        {
            return Results.NotFound("Bank ID does not exist");
        }
    }

}