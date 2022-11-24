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
        var currency = currencyService.get();
        if (currency.Any())
        {
            return Ok(currency);
        }
        else
        {
            return NotFound("No currencies available");
        }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetOne(string id)
    {
        var currency = await currencyService.findOne(id);
        if (currency != null)
        {
            return Results.Accepted($"Currency information with the ID:   {id}", currency);
        }
        else
        {
            return Results.NotFound($"Currency not found by ID :  {id}");
        }


    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CurrencyModel currency)
    {
        if (await currencyService.findOne(currency.Currency_id) == null)
        {
            await currencyService.save(currency);
            return Results.Created("Currency created", currency);
        }
        else
        {
            return Results.Conflict("Currency ID already exist, please type another ID again");
        }
    }
    [HttpPut("{id}")]
    public async Task<IResult> Put(string id, [FromBody] CurrencyModel currency)
    {
        if (await currencyService.findOne(id) != null)
        {
            await currencyService.update(id, currency);
            return Results.Accepted("It has been updated successfully!");
        }
        else
        {
            return Results.NotFound("Company ID does not exist");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
        if (await currencyService.findOne(id) != null)
        {
            await currencyService.delete(id);
            return Results.Accepted("It has been removed successfully!");
        }
        else
        {
            return Results.NotFound("Currency ID does not exist");
        }
    }


}