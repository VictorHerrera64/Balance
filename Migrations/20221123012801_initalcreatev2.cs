using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace balance.Migrations
{
    /// <inheritdoc />
    public partial class initalcreatev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Currencies_Country_id",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "Country_id",
                table: "Currencies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Country_id",
                table: "Currencies",
                column: "Country_id",
                unique: true,
                filter: "[Country_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Countries_Country_id",
                table: "Currencies",
                column: "Country_id",
                principalTable: "Countries",
                principalColumn: "Country_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Countries_Country_id",
                table: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_Country_id",
                table: "Currencies");

            migrationBuilder.AlterColumn<string>(
                name: "Country_id",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Currencies_Country_id",
                table: "Countries",
                column: "Country_id",
                principalTable: "Currencies",
                principalColumn: "Currency_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
