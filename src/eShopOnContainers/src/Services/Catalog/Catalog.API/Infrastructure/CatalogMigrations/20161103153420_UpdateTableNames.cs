namespace Catalog.API.Infrastructure.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_catalog_catalogbrand_CatalogBrandId",
                "catalog");

            migrationBuilder.DropForeignKey(
                "FK_catalog_CatalogTypes_CatalogTypeId",
                "catalog");

            migrationBuilder.DropPrimaryKey(
                "PK_CatalogTypes",
                "CatalogTypes");

            migrationBuilder.DropPrimaryKey(
                "PK_catalog",
                "catalog");

            migrationBuilder.DropPrimaryKey(
                "PK_catalogbrand",
                "catalogbrand");

            migrationBuilder.AddPrimaryKey(
                "PK_CatalogType",
                "CatalogTypes",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_Catalog",
                "catalog",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_CatalogBrand",
                "catalogbrand",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_Catalog_CatalogBrand_CatalogBrandId",
                "catalog",
                "CatalogBrandId",
                "catalogbrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Catalog_CatalogType_CatalogTypeId",
                "catalog",
                "CatalogTypeId",
                "CatalogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                "IX_catalog_CatalogTypeId",
                table: "catalog",
                newName: "IX_Catalog_CatalogTypeId");

            migrationBuilder.RenameIndex(
                "IX_catalog_CatalogBrandId",
                table: "catalog",
                newName: "IX_Catalog_CatalogBrandId");

            migrationBuilder.RenameTable(
                "CatalogTypes",
                newName: "CatalogType");

            migrationBuilder.RenameTable(
                "catalog",
                newName: "Catalog");

            migrationBuilder.RenameTable(
                "catalogbrand",
                newName: "CatalogBrand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Catalog_CatalogBrand_CatalogBrandId",
                "Catalog");

            migrationBuilder.DropForeignKey(
                "FK_Catalog_CatalogType_CatalogTypeId",
                "Catalog");

            migrationBuilder.DropPrimaryKey(
                "PK_CatalogType",
                "CatalogType");

            migrationBuilder.DropPrimaryKey(
                "PK_Catalog",
                "Catalog");

            migrationBuilder.DropPrimaryKey(
                "PK_CatalogBrand",
                "CatalogBrand");

            migrationBuilder.AddPrimaryKey(
                "PK_CatalogTypes",
                "CatalogType",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_catalog",
                "Catalog",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_catalogbrand",
                "CatalogBrand",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_catalog_catalogbrand_CatalogBrandId",
                "Catalog",
                "CatalogBrandId",
                "CatalogBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_catalog_CatalogTypes_CatalogTypeId",
                "Catalog",
                "CatalogTypeId",
                "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                "IX_Catalog_CatalogTypeId",
                table: "Catalog",
                newName: "IX_catalog_CatalogTypeId");

            migrationBuilder.RenameIndex(
                "IX_Catalog_CatalogBrandId",
                table: "Catalog",
                newName: "IX_catalog_CatalogBrandId");

            migrationBuilder.RenameTable(
                "CatalogType",
                newName: "CatalogTypes");

            migrationBuilder.RenameTable(
                "Catalog",
                newName: "catalog");

            migrationBuilder.RenameTable(
                "CatalogBrand",
                newName: "catalogbrand");
        }
    }
}
