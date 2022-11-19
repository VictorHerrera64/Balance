﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using balance;

#nullable disable

namespace balance.Migrations
{
    [DbContext(typeof(BalanceContext))]
    [Migration("20221119020636_testv4")]
    partial class testv4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("balance.Models.AccountModel", b =>
                {
                    b.Property<string>("Account_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Account_type")
                        .HasColumnType("int");

                    b.Property<string>("Bank_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Company_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Country_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency_id_account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency_id_local")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("User_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Account_id");

                    b.HasIndex("Bank_id");

                    b.HasIndex("Company_id");

                    b.HasIndex("Country_id");

                    b.HasIndex("Currency_id_local")
                        .IsUnique()
                        .HasFilter("[Currency_id_local] IS NOT NULL");

                    b.HasIndex("User_id");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("balance.Models.BankModel", b =>
                {
                    b.Property<string>("Bank_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Bank_name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Bank_id");

                    b.ToTable("Banks", (string)null);
                });

            modelBuilder.Entity("balance.Models.CompanyModel", b =>
                {
                    b.Property<string>("Company_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Company_name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Country_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency_id_local")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Company_id");

                    b.HasIndex("Country_id");

                    b.HasIndex("Currency_id_local")
                        .IsUnique()
                        .HasFilter("[Currency_id_local] IS NOT NULL");

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("balance.Models.CountryModel", b =>
                {
                    b.Property<string>("Country_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Country_name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Country_id");

                    b.ToTable("Countries", (string)null);
                });

            modelBuilder.Entity("balance.Models.CurrencyModel", b =>
                {
                    b.Property<string>("Currency_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency_name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Currency_id");

                    b.ToTable("Currencies", (string)null);
                });

            modelBuilder.Entity("balance.Models.UserModel", b =>
                {
                    b.Property<string>("User_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("User_name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("User_id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("balance.Models.AccountModel", b =>
                {
                    b.HasOne("balance.Models.BankModel", "Bank")
                        .WithMany("Accounts")
                        .HasForeignKey("Bank_id");

                    b.HasOne("balance.Models.CompanyModel", "Company")
                        .WithMany("Accounts")
                        .HasForeignKey("Company_id");

                    b.HasOne("balance.Models.CountryModel", "Country")
                        .WithMany("Accounts")
                        .HasForeignKey("Country_id");

                    b.HasOne("balance.Models.CurrencyModel", "Currency")
                        .WithOne("Account")
                        .HasForeignKey("balance.Models.AccountModel", "Currency_id_local");

                    b.HasOne("balance.Models.UserModel", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("User_id");

                    b.Navigation("Bank");

                    b.Navigation("Company");

                    b.Navigation("Country");

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("balance.Models.CompanyModel", b =>
                {
                    b.HasOne("balance.Models.CountryModel", "Country")
                        .WithMany("Companies")
                        .HasForeignKey("Country_id");

                    b.HasOne("balance.Models.CurrencyModel", "Currency")
                        .WithOne("Company")
                        .HasForeignKey("balance.Models.CompanyModel", "Currency_id_local");

                    b.Navigation("Country");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("balance.Models.BankModel", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("balance.Models.CompanyModel", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("balance.Models.CountryModel", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Companies");
                });

            modelBuilder.Entity("balance.Models.CurrencyModel", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("balance.Models.UserModel", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
