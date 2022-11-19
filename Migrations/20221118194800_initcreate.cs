using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace balance.Migrations
{
    /// <inheritdoc />
    public partial class initcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Bankid = table.Column<string>(name: "Bank_id", type: "nvarchar(450)", nullable: false),
                    Bankname = table.Column<string>(name: "Bank_name", type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Createdat = table.Column<DateTime>(name: "Created_at", type: "datetime2", nullable: false),
                    Updatedat = table.Column<DateTime>(name: "Updated_at", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Bankid);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Countryid = table.Column<string>(name: "Country_id", type: "nvarchar(450)", nullable: false),
                    Countryname = table.Column<string>(name: "Country_name", type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Createdat = table.Column<DateTime>(name: "Created_at", type: "datetime2", nullable: false),
                    Updatedat = table.Column<DateTime>(name: "Updated_at", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Countryid);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Currencyid = table.Column<string>(name: "Currency_id", type: "nvarchar(450)", nullable: false),
                    Currencyname = table.Column<string>(name: "Currency_name", type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Createdat = table.Column<DateTime>(name: "Created_at", type: "datetime2", nullable: false),
                    Updatedat = table.Column<DateTime>(name: "Updated_at", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Currencyid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Userid = table.Column<string>(name: "User_id", type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(name: "User_name", type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Createdat = table.Column<DateTime>(name: "Created_at", type: "datetime2", nullable: false),
                    Updatedat = table.Column<DateTime>(name: "Updated_at", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Userid);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Companyid = table.Column<string>(name: "Company_id", type: "nvarchar(450)", nullable: false),
                    Companyname = table.Column<string>(name: "Company_name", type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Countryid = table.Column<string>(name: "Country_id", type: "nvarchar(450)", nullable: true),
                    Currencyidlocal = table.Column<string>(name: "Currency_id_local", type: "nvarchar(450)", nullable: true),
                    Createdat = table.Column<DateTime>(name: "Created_at", type: "datetime2", nullable: false),
                    Updatedat = table.Column<DateTime>(name: "Updated_at", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Companyid);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_Country_id",
                        column: x => x.Countryid,
                        principalTable: "Countries",
                        principalColumn: "Country_id");
                    table.ForeignKey(
                        name: "FK_Companies_Currencies_Currency_id_local",
                        column: x => x.Currencyidlocal,
                        principalTable: "Currencies",
                        principalColumn: "Currency_id");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Accountid = table.Column<string>(name: "Account_id", type: "nvarchar(450)", nullable: false),
                    Accounttype = table.Column<int>(name: "Account_type", type: "int", nullable: false),
                    Companyid = table.Column<string>(name: "Company_id", type: "nvarchar(450)", nullable: true),
                    Countryid = table.Column<string>(name: "Country_id", type: "nvarchar(450)", nullable: true),
                    Bankid = table.Column<string>(name: "Bank_id", type: "nvarchar(450)", nullable: true),
                    Currencyidaccount = table.Column<string>(name: "Currency_id_account", type: "nvarchar(max)", nullable: true),
                    Currencyidlocal = table.Column<string>(name: "Currency_id_local", type: "nvarchar(450)", nullable: true),
                    Userid = table.Column<string>(name: "User_id", type: "nvarchar(450)", nullable: true),
                    Createdat = table.Column<DateTime>(name: "Created_at", type: "datetime2", nullable: false),
                    Updatedat = table.Column<DateTime>(name: "Updated_at", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Accountid);
                    table.ForeignKey(
                        name: "FK_Accounts_Banks_Bank_id",
                        column: x => x.Bankid,
                        principalTable: "Banks",
                        principalColumn: "Bank_id");
                    table.ForeignKey(
                        name: "FK_Accounts_Companies_Company_id",
                        column: x => x.Companyid,
                        principalTable: "Companies",
                        principalColumn: "Company_id");
                    table.ForeignKey(
                        name: "FK_Accounts_Countries_Country_id",
                        column: x => x.Countryid,
                        principalTable: "Countries",
                        principalColumn: "Country_id");
                    table.ForeignKey(
                        name: "FK_Accounts_Currencies_Currency_id_local",
                        column: x => x.Currencyidlocal,
                        principalTable: "Currencies",
                        principalColumn: "Currency_id");
                    table.ForeignKey(
                        name: "FK_Accounts_Users_User_id",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "User_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Bank_id",
                table: "Accounts",
                column: "Bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Company_id",
                table: "Accounts",
                column: "Company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Country_id",
                table: "Accounts",
                column: "Country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Currency_id_local",
                table: "Accounts",
                column: "Currency_id_local",
                unique: true,
                filter: "[Currency_id_local] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_User_id",
                table: "Accounts",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Country_id",
                table: "Companies",
                column: "Country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Currency_id_local",
                table: "Companies",
                column: "Currency_id_local",
                unique: true,
                filter: "[Currency_id_local] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
