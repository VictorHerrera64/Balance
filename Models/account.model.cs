using System.Text.Json.Serialization;
namespace balance.Models;

public class AccountModel
{
    //attributes
    // getters and setters
    public string? Account_id { get; set; }
    public AccountType Account_type { get; set; }
    public string? Company_id { get; set; }
    public string? Country_id { get; set; }
    public string? Bank_id { get; set; }
    public string? Currency_id_account { get; set; }
    public string? Currency_id_local { get; set; }
    public string? User_id { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }

    
    public virtual CompanyModel? Company { get; set; }
    
    public virtual CountryModel? Country { get; set; }
    
    public virtual BankModel? Bank { get; set; }
    
    public virtual CurrencyModel? Currency { get; set; }
    
    public virtual UserModel? User { get; set; }
}

public enum AccountType { current_account, savings_account }
