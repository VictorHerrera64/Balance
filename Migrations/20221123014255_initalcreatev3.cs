using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace balance.Migrations
{
    /// <inheritdoc />
    public partial class initalcreatev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Currencies_Currency_id",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Currency_id",
                table: "Accounts",
                newName: "Currency_id_account");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_Currency_id",
                table: "Accounts",
                newName: "IX_Accounts_Currency_id_account");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Currencies_Currency_id_account",
                table: "Accounts",
                column: "Currency_id_account",
                principalTable: "Currencies",
                principalColumn: "Currency_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Currencies_Currency_id_account",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Currency_id_account",
                table: "Accounts",
                newName: "Currency_id");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_Currency_id_account",
                table: "Accounts",
                newName: "IX_Accounts_Currency_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Currencies_Currency_id",
                table: "Accounts",
                column: "Currency_id",
                principalTable: "Currencies",
                principalColumn: "Currency_id");
        }
    }
}
