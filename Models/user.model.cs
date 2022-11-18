using System.Collections.Generic;
namespace balance.Models;
public class UserModel
{
    //attributes
    // getters and setter
    public string? User_id { get; set; }
    public string? User_name { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public virtual ICollection<AccountModel>? Accounts { get; set; }


   

}