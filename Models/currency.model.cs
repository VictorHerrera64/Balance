using System.Text.Json.Serialization;

namespace balance.Models;

public class CurrencyModel
{
    //attributes
    // getters and setter
    public string? Currency_id { get; set; }
    public string? Currency_name { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }

    [JsonIgnore]
     public virtual CompanyModel? Company{get;set;}
     [JsonIgnore]
    public virtual AccountModel? Account{get;set;}
   

}