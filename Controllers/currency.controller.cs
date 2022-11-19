using balance.Models;
using balance.Services;
using Microsoft.AspNetCore.Mvc;
namespace balance.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CurrencyController : ControllerBase
{
    ICurrencyService currencyService;
    public CurrencyController(ICurrencyService service)
    {
        currencyService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(currencyService.get());
    }

    [HttpGet("{id_currency}")]
    public async Task<IResult> GetOne(string id_currency)
    {
        var currency = await currencyService.findOne(id_currency);
        return Results.Accepted($"Currency encontrado por el id :  {id_currency}", currency);

    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CurrencyModel currency)
    {
        await currencyService.save(currency);
        return Results.Created("Currency creado", currency);
    }
     [HttpPut("{id}")]
    public async Task<IResult> Put(string  id, [FromBody] CurrencyModel currency)
    {
       await currencyService.update(id,currency);
       return Results.Accepted("Se ha actualizado con exito!", currency);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
       await currencyService.delete(id);
       return Results.Accepted("Se ha eliminado con exito!", id);
    }

}