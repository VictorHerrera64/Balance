using balance.Models;
using Microsoft.EntityFrameworkCore;
namespace balance.Services;

public class CurrencyService: ICurrencyService
{
    BalanceContext context;


    public CurrencyService(BalanceContext dbContext) => context = dbContext;

    public IEnumerable<CurrencyModel> get()
    {
        return context.Currencies;
    }
    public async Task<CurrencyModel> findOne(string id_currency)
    {
        var response = await context.Currencies.FindAsync(id_currency);
        return response;
    }

    public async Task save(CurrencyModel currency)
    {
         currency.Created_at = DateTime.Now;
        await context.AddAsync(currency);
        await context.SaveChangesAsync();   
    }
    

    public async Task update(string id_currency, CurrencyModel currency)
    {
        var response = await context.Currencies.FindAsync(id_currency);
        if (response != null)
        {
            response.Currency_name = currency.Currency_name;
            response.Updated_at = DateTime.Now;
            await context.SaveChangesAsync();
        }
    }

    public async Task delete(string id_currency)
    {
        var response = await context.Currencies.FindAsync(id_currency);
        if (response != null)
        {
            context.Remove(response);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICurrencyService
{
    IEnumerable<CurrencyModel> get();
    Task<CurrencyModel> findOne(string id_currency);
    Task save(CurrencyModel currency);
    Task update(string id_currency, CurrencyModel currency);
    Task delete(string id_currency);
}






