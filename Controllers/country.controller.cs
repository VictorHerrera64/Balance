using balance.Models;
using balance.Services;
using Microsoft.AspNetCore.Mvc;
namespace balance.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    ICountryService countryService;
    public CountryController(ICountryService service)
    {
        countryService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
         var country = countryService.get();
        if (country.Any())
        {
            return Ok(country);
        }
        else
        {
            return NotFound("No countries available");
        }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetOne(string id)
    {
        var country = await countryService.findOne(id);
        if (country != null)
        {
            return Results.Accepted($"Country information with the ID:   {id}", country);
        }
        else
        {
            return Results.NotFound($"Country not found by ID :  {id}");
        }
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CountryModel country)
    {
        await countryService.save(country);
        return Results.Created("Country created", country);
    }
     [HttpPut("{id}")]
    public async Task<IResult> Put(string  id, [FromBody] CountryModel country)
    {
       if (await countryService.findOne(id) != null)
        {
            await countryService.update(id, country);
            return Results.Accepted("It has been updated successfully!");
        }
        else
        {
            return Results.NotFound("Country ID does not exist");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
     if (await countryService.findOne(id) != null)
        {
            await countryService.delete(id);
            return Results.Accepted("It has been removed successfully!");
        }
        else
        {
            return Results.NotFound("Country ID does not exist");
        }
    }

}