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
        return Ok(countryService.get());
    }

    [HttpGet("{id_country}")]
    public async Task<IResult> GetOne(string id_country)
    {
        var country = await countryService.findOne(id_country);
        return Results.Accepted($"Country encontrado por el id :  {id_country}", country);

    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CountryModel country)
    {
        await countryService.save(country);
        return Results.Created("Country creado", country);
    }
     [HttpPut("{id}")]
    public async Task<IResult> Put(string  id, [FromBody] CountryModel country)
    {
       await countryService.update(id,country);
       return Results.Accepted("Se ha actualizado con exito!", country);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
       await countryService.delete(id);
       return Results.Accepted("Se ha eliminado con exito!", id);
    }

}