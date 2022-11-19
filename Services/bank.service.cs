using balance.Models;
using Microsoft.EntityFrameworkCore;
namespace balance.Services;

public class BankService: IBankService
{
    BalanceContext context;


    public BankService(BalanceContext dbContext) => context = dbContext;

    public IEnumerable<BankModel> get()
    {
        return context.Banks;
    }
    public async Task<BankModel> findOne(string id_bank)
    {
        var response = await context.Banks.FindAsync(id_bank);
        return response;
    }

    public async Task save(BankModel bank)
    {
         bank.Created_at = DateTime.Now;
        await context.AddAsync(bank);
        await context.SaveChangesAsync();   
    }
    

    public async Task update(string id_bank, BankModel bank)
    {
        var response = await context.Banks.FindAsync(id_bank);
        if (response != null)
        {
            response.Bank_name = bank.Bank_name;
            response.Updated_at = DateTime.Now;
            await context.SaveChangesAsync();
        }
    }

    public async Task delete(string id_bank)
    {
        var response = await context.Banks.FindAsync(id_bank);
        if (response != null)
        {
            context.Remove(response);
            await context.SaveChangesAsync();
        }
    }
}

public interface IBankService
{
    IEnumerable<BankModel> get();
    Task<BankModel> findOne(string id_bank);
    Task save(BankModel bank);
    Task update(string id_bank, BankModel bank);
    Task delete(string id_bank);
}

