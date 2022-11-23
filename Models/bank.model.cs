using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace balance.Models;
public class BankModel
{
    //attributes
    // getters and setters
    public string? Bank_id { get; set; }
    public string? Bank_name { get; set; }
    public string? Country_id{ get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }

    [JsonIgnore]
    public virtual ICollection<AccountModel>? Accounts { get; set; }
    [JsonIgnore]
    public virtual CountryModel? Country { get; set; }

}