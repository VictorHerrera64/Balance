using balance.Models;
using balance.Services;
using Microsoft.AspNetCore.Mvc;
namespace balance.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    ICompanyService companyService;
    public CompanyController(ICompanyService service)
    {
       companyService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(companyService.get());
    }

    [HttpGet("{id_company}")]
    public async Task<IResult> GetOne(string id_company)
    {
        var company = await companyService.findOne(id_company);
        return Results.Accepted($"Company encontrado por el id :  {id_company}", company);

    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CompanyModel company)
    {
        await companyService.save(company);
        return Results.Created("Company creado", company);
    }
     [HttpPut("{id}")]
    public async Task<IResult> Put(string  id, [FromBody] CompanyModel company)
    {
       await companyService.update(id,company);
       return Results.Accepted("Se ha actualizado con exito!", company);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> delete(string id)
    {
       await companyService.delete(id);
       return Results.Accepted("Se ha eliminado con exito!", id);
    }

}