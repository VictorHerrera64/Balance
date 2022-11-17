namespace balance.Models;

public class AccountModel
{
    //attributes
    private string? account_id;
    private AccountType account_type;
    private string? company_id;
    private string? country_id;
    private string? bank_id;
    private string? currency_id_account;
    private string? currency_id_local;
    private string? user_id;


    // getters and setters
    public string Account_id { get; set; }
    public AccountType Account_type { get; set; }
    public string Company_id { get; set; }
    public string Country_id { get; set; }
    public string Bank_id { get; set; }
    public string Currency_id_account { get; set; }
    public string Currency_id_local { get; set; }
    public string User_id { get; set; }

    public virtual CompanyModel? Company{get;set;}
    public virtual CountryModel? Country{get;set;}
    public virtual BankModel? Bank{get;set;}
    public virtual CurrencyModel? Currency{get;set;}
    public virtual UserModel? User{get;set;}
   
    //constructor
    public AccountModel(
        string account, AccountType type, string company,
        string country, string bank, string currency_account,
        string currency_local, string user
    ) => (Account_id, Account_type, Company_id,
    Country_id, Bank_id, Currency_id_account,
    Currency_id_local, User_id
    ) = (account, type, company,
    country, bank, currency_account,
    currency_local, user
    );


}

public enum AccountType { current_account, savings_account }
