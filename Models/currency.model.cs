namespace balance.Models;

public class CurrencyModel
{
    //attributes
    private string? currency_id;
    private string? currency_name;

    // getters and setter
    public string Currency_id { get; set; }
    public string Currency_name { get; set; }

     public virtual CompanyModel? Company{get;set;}
    public virtual AccountModel? Account{get;set;}
    //constructor
    public CurrencyModel(string id, string name) => (Currency_id, Currency_name) = (id, name);

}