using System.Collections.Generic;
namespace balance.Models;
public class BankModel
{
    //attributes
    // getters and setters
    public string? Bank_id { get; set; }
    public string? Bank_name { get; set; }
     public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }

    public virtual ICollection<AccountModel>?Accounts{get;set;}
    
}