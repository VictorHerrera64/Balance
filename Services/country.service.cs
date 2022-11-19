using balance.Models;
using Microsoft.EntityFrameworkCore;
namespace balance.Services;

public class CountryService: ICountryService
{
    BalanceContext context;


    public CountryService(BalanceContext dbContext) => context = dbContext;

    public IEnumerable<CountryModel> get()
    {
        return context.Countries;
    }
    public async Task<CountryModel> findOne(string id_country)
    {
        var response = await context.Countries.FindAsync(id_country);
        return response;
    }

    public async Task save(CountryModel country)
    {
         country.Created_at = DateTime.Now;
        await context.AddAsync(country);
        await context.SaveChangesAsync();   
    }
    

    public async Task update(string id_country, CountryModel country)
    {
        var response = await context.Countries.FindAsync(id_country);
        if (response != null)
        {
            response.Country_name = country.Country_name;
            response.Updated_at = DateTime.Now;
            await context.SaveChangesAsync();
        }
    }

    public async Task delete(string id_country)
    {
        var response = await context.Countries.FindAsync(id_country);
        if (response != null)
        {
            context.Remove(response);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICountryService
{
 IEnumerable<CountryModel> get();
 Task<CountryModel> findOne(string id_country);
 Task save(CountryModel country);
Task update(string id_country, CountryModel country);
 Task delete(string id_country);

}

