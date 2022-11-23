using balance.Models;
using Microsoft.EntityFrameworkCore;
namespace balance.Services;

public class CompanyService: ICompanyService
{
    BalanceContext context;


    public CompanyService(BalanceContext dbContext) => context = dbContext;

    public IEnumerable<CompanyModel> get()
    {
        return context.Companies;
    }
    public async Task<CompanyModel> findOne(string id_company)
    {
        var response = await context.Companies.FindAsync(id_company);
        return response;
    }

    public async Task save(CompanyModel company)
    {
         company.Created_at = DateTime.Now;
        await context.AddAsync(company);
        await context.SaveChangesAsync();   
    }
    

    public async Task update(string id_company, CompanyModel company)
    {
        var response = await context.Companies.FindAsync(id_company);
        if (response != null)
        {
            response.Company_name = company.Company_name;
            response.Country_id = company.Country_id;
            response.Updated_at = DateTime.Now;
            await context.SaveChangesAsync();
        }
    }

    public async Task delete(string id_company)
    {
        var response = await context.Companies.FindAsync(id_company);
        if (response != null)
        {
            context.Remove(response);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICompanyService
{
    IEnumerable<CompanyModel> get();
    Task<CompanyModel> findOne(string id_company);
    Task save(CompanyModel company);
    Task update(string id_company, CompanyModel company);
    Task delete(string id_company);
}

