using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SmartParkingConext3DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandDTOID",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_BrandDTOID",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "BrandDTOID",
                table: "Models");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandID",
                table: "Models",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ClientID",
                table: "Locations",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Clients_ClientID",
                table: "Locations",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandID",
                table: "Models",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Clients_ClientID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandID",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_BrandID",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ClientID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "BrandDTOID",
                table: "Models",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandDTOID",
                table: "Models",
                column: "BrandDTOID");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandDTOID",
                table: "Models",
                column: "BrandDTOID",
                principalTable: "Brands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
