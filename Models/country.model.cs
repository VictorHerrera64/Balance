namespace balance.Models;

public class CountryModel
{
    //attributes
    // getters and setter
    public string? Country_id { get; set; }
    public string? Country_name { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }

    public virtual ICollection<CompanyModel>? Companies { get; set; }
    public virtual ICollection<AccountModel>?Accounts{get;set;}


}