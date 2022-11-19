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
        return Ok(bankService.get());
    }

    [HttpGet("{id_bank}")]
    public async Task<IResult> GetOne(string id_bank)
    {
        var bank = await bankService.findOne(id_bank);
        return Results.Accepted($"bank encontrado por el id :  {id_bank}", bank);

    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] BankModel bank)
    {
        await bankService.save(bank);
        return Results.Created("bank creado", bank);
    }
     [HttpPut("{id}")]
    public async Task<IResult> Put(string  id, [FromBody] BankModel bank)
    {
       await bankService.update(id,bank);
       return Results.Accepted("Se ha actualizado con exito!", bank);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
       await bankService.delete(id);
       return Results.Accepted("Se ha eliminado con exito!", id);
    }

}