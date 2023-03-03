namespace Catalog.API.Infrastructure.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddStockProductItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "AvailableStock",
                "Catalog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "MaxStockThreshold",
                "Catalog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                "OnReorder",
                "Catalog",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                "RestockThreshold",
                "Catalog",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "AvailableStock",
                "Catalog");

            migrationBuilder.DropColumn(
                "MaxStockThreshold",
                "Catalog");

            migrationBuilder.DropColumn(
                "OnReorder",
                "Catalog");

            migrationBuilder.DropColumn(
                "RestockThreshold",
                "Catalog");
        }
    }
}
