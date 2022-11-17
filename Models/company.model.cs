namespace balance.Models;

public class CompanyModel
{
    //attributes
    private string? company_id;
    private string? company_name;
    private string? country_id;
    private string? currency_id_local;
    private DateTime? created_at;
    private DateTime? updated_at;

    // getters and setter
    public string Company_id { get; set; }
    public string Company_name { get; set; }
    public string Country_id { get; set; }
    public string Currency_id_local { get; set; }
     public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }

    
    public virtual CountryModel? Country{get;set;}
    public virtual CurrencyModel? Currency{get;set;}
     public virtual ICollection<AccountModel>?Accounts{get;set;}
       
        
    //constructor
    public CompanyModel(string id, string name,
    string country, string currency) => (
        Company_id, Company_name, Country_id, Currency_id_local) = (id, name, country, currency);

}