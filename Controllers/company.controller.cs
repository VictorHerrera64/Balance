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
        var company = companyService.get();
        if (company.Any())
        {
            return Ok(company);
        }
        else
        {
            return NotFound("No companies available");
        }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetOne(string id)
    {
        var company = await companyService.findOne(id);
        if (company != null)
        {
            return Results.Accepted($"Company information with the ID:   {id}", company);
        }
        else
        {
            return Results.NotFound($"Company not found by ID :  {id}");
        }

    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] CompanyModel company)
    {
        if (await companyService.findOne(company.Company_id) == null)
        {
            await companyService.save(company);
            return Results.Created("Company created", company);
        }
        else
        {
            return Results.Conflict("Company ID already exist, please type another ID again");
        }
    }
    [HttpPut("{id}")]
    public async Task<IResult> Put(string id, [FromBody] CompanyModel company)
    {
        if (await companyService.findOne(id) != null)
        {
            await companyService.update(id, company);
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
        if (await companyService.findOne(id) != null)
        {
            await companyService.delete(id);
            return Results.Accepted("It has been removed successfully!");
        }
        else
        {
            return Results.NotFound("Company ID does not exist");
        }
    }

}