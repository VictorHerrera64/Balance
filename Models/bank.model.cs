using System.Collections.Generic;
namespace balance.Models;
public class BankModel
{
    //attributes
    private string? bank_id;
    private string? bank_name;

    // getters and setters
    public string Bank_id { get; set; }
    public string Bank_name { get; set; }

    public virtual ICollection<AccountModel>?Accounts{get;set;}
    

    //constructor
    public BankModel(string id, string name) => (Bank_id, Bank_name) = (id, name);

}