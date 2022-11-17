namespace balance;
using balance.Models;
using Microsoft.EntityFrameworkCore;

public class BalanceContext : DbContext
{
    public DbSet<AccountModel>? Accounts { get; set; }
    public DbSet<CompanyModel>? Companies { get; set; }
    public DbSet<BankModel>? Banks { get; set; }
    public DbSet<CountryModel>? Countries { get; set; }
    public DbSet<CurrencyModel>? Currencies { get; set; }
    public DbSet<UserModel>? Users { get; set; }

    public BalanceContext(DbContextOptions<BalanceContext> Options): base(Options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(user =>
        {
            user.ToTable("Users");
            user.HasKey(p => p.User_id);
            user.Property(p => p.User_name).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<CurrencyModel>(currency =>
        {
            currency.ToTable("Currencies");
            currency.HasKey(p => p.Currency_id);
            currency.Property(p => p.Currency_name).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<CountryModel>(country =>
        {
            country.ToTable("Countries");
            country.HasKey(p => p.Country_id);
            country.Property(p => p.Country_name).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<BankModel>(bank =>
        {
            bank.ToTable("Banks");
            bank.HasKey(p => p.Bank_id);
            bank.Property(p => p.Bank_name).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<CompanyModel>(company =>
        {
            company.ToTable("Companies");
            company.HasKey(p => p.Company_id);
            company.Property(p => p.Company_name).IsRequired().HasMaxLength(150);
            // One To Many Relationship
            company.HasOne(p=>p.Country).WithMany(p=>p.Companies).HasForeignKey(p=>p.Country_id);
            // One To One Relationship
            company.HasOne(p=>p.Currency).WithOne(p=>p.Company).HasForeignKey<CompanyModel>(p=>p.Currency_id_local);
            
        });

        modelBuilder.Entity<AccountModel>(account =>{
            account.ToTable("Accounts");
            account.HasKey(p=>p.Account_id);
            account.Property(p=>p.Account_type).IsRequired();
            // One To Many Relationship
            account.HasOne(p=>p.Company).WithMany(p=>p.Accounts).HasForeignKey(p=>p.Company_id);
            account.HasOne(p=>p.Country).WithMany(p=>p.Accounts).HasForeignKey(p=>p.Country_id);
            account.HasOne(p=>p.Bank).WithMany(p=>p.Accounts).HasForeignKey(p=>p.Bank_id);
            account.HasOne(p=>p.User).WithMany(p=>p.Accounts).HasForeignKey(p=>p.User_id);
            // One To One  Relationship
            account.HasOne(p=>p.Currency).WithOne(p=>p.Account).HasForeignKey<AccountModel>(p=>p.Currency_id_account);
            account.HasOne(p=>p.Currency).WithOne(p=>p.Account).HasForeignKey<AccountModel>(p=>p.Currency_id_local);

        });

    }

}