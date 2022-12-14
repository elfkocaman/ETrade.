using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETrade.Dal.Migrations
{
    public partial class VAT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VatId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_VatId",
                table: "Products",
                column: "VatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Vat_VatId",
                table: "Products",
                column: "VatId",
                principalTable: "Vat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Vat_VatId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_VatId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VatId",
                table: "Products");
        }
    }
}
