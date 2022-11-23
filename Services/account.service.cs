using balance.Models;
using Microsoft.EntityFrameworkCore;
namespace balance.Services;

public class AccountService : IAccountService
{
    BalanceContext context;


    public AccountService(BalanceContext dbContext) => context = dbContext;

    public IEnumerable<AccountModel> get()
    {
        return context.Accounts
        .Include(p => p.Company)
        .Include(p => p.Country)
        .Include(p => p.Bank)
        .Include(p => p.Currency)
        .Include(p => p.User);
    }
    public async Task<AccountModel> findOne(string id_account)
    {
        var response = await context.Accounts.FindAsync(id_account);
        return response;
    }

    public async Task save(AccountModel account)
    {
        account.Created_at = DateTime.Now;
        await context.AddAsync(account);
        await context.SaveChangesAsync();
    }


    public async Task update(string id_account, AccountModel account)
    {
        var response = await context.Accounts.FindAsync(id_account);
        if (response != null)
        {
            response.Account_type = account.Account_type;
            response.Company_id = account.Company_id;
            response.Country_id = account.Country_id;
            response.Bank_id = account.Bank_id;
            response.Currency_id_account = account.Currency_id_account;
            response.User_id = account.User_id;
            response.Updated_at = DateTime.Now;
            await context.SaveChangesAsync();
        }
    }

    public async Task delete(string id_account)
    {
        var response = await context.Accounts.FindAsync(id_account);
        if (response != null)
        {
            context.Remove(response);
            await context.SaveChangesAsync();
        }
    }
}

public interface IAccountService
{
    IEnumerable<AccountModel> get();
    Task<AccountModel> findOne(string id_account);
    Task save(AccountModel account);
    Task update(string id_account, AccountModel account);
    Task delete(string id_account);
}

