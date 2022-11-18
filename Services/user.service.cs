using balance.Models;
using Microsoft.EntityFrameworkCore;
namespace balance.Services;

public class UserService: IUserService
{
    BalanceContext context;


    public UserService(BalanceContext dbContext) => context = dbContext;

    public IEnumerable<UserModel> get()
    {
        return context.Users.Include(p=>p.Accounts);
    }
    public async Task<UserModel> findOne(string id_user)
    {
        var response = await context.Users.FindAsync(id_user);
        return response;
    }

    public async Task save(UserModel user)
    {
         user.Created_at = DateTime.Now;
        await context.AddAsync(user);
        await context.SaveChangesAsync();   
    }
    

    public async Task update(string id_user, UserModel user)
    {
        var response = await context.Users.FindAsync(id_user);
        if (response != null)
        {
            response.User_name = user.User_name;
            response.Updated_at = DateTime.Now;
            await context.SaveChangesAsync();
        }
    }

    public async Task delete(string id_user)
    {
        var response = await context.Users.FindAsync(id_user);
        if (response != null)
        {
            context.Remove(response);
            await context.SaveChangesAsync();
        }
    }
}

public interface IUserService
{
    IEnumerable<UserModel> get();
    Task<UserModel> findOne(string id_user);
    Task save(UserModel user);
    Task update(string id_user, UserModel user);
    Task delete(string id_user);
}
