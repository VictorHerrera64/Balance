using System.Text.Json.Serialization;

namespace balance.Models;

public class CompanyModel
{
    //attributes
    // getters and setter
    public string? Company_id { get; set; }
    public string? Company_name { get; set; }
    public string? Country_id { get; set; }
    public string? Currency_id_local { get; set; }
     public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }

    [JsonIgnore]
    public virtual CountryModel? Country{get;set;}
    [JsonIgnore]
    public virtual CurrencyModel? Currency{get;set;}

    [JsonIgnore]
     public virtual ICollection<AccountModel>?Accounts{get;set;}
       
        
    

}