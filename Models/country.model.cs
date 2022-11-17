namespace balance.Models;

public class CountryModel
{
    //attributes
    private string? country_id;
    private string? country_name;

    // getters and setter
    public string Country_id { get; set; }
    public string Country_name { get; set; }

    public virtual ICollection<CompanyModel>? Companies { get; set; }
    public virtual ICollection<AccountModel>?Accounts{get;set;}
    //constructor
    public CountryModel(string id, string name) => (Country_id, Country_name) = (id, name);

}