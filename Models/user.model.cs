using System.Collections.Generic;
namespace balance.Models;
public class UserModel
{
    //attributes
    private string? user_id;
    private string? user_name;

    // getters and setter
    public string User_id { get; set; }
    public string User_name { get; set; }
    public virtual ICollection<AccountModel>? Accounts { get; set; }


    //constructor
    public UserModel(string id, string name) => (User_id, User_name) = (id, name);

}