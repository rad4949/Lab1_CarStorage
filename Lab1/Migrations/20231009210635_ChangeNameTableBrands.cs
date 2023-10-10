using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab1.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameTableBrands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_BrandCar_BrandId",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandCar",
                table: "BrandCar");

            migrationBuilder.RenameTable(
                name: "BrandCar",
                newName: "BrandCars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandCars",
                table: "BrandCars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_BrandCars_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "BrandCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_BrandCars_BrandId",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandCars",
                table: "BrandCars");

            migrationBuilder.RenameTable(
                name: "BrandCars",
                newName: "BrandCar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandCar",
                table: "BrandCar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_BrandCar_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "BrandCar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
