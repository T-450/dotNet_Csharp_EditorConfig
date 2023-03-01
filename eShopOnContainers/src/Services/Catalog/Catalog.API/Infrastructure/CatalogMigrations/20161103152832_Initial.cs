namespace Catalog.API.Infrastructure.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                "catalog_brand_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                "catalog_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                "catalogbrand",
                table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(maxLength: 100, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogbrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "CatalogTypes",
                table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "catalog",
                table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CatalogBrandId = table.Column<int>(nullable: false),
                    CatalogTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PictureUri = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalog", x => x.Id);
                    table.ForeignKey(
                        "FK_catalog_catalogbrand_CatalogBrandId",
                        x => x.CatalogBrandId,
                        "catalogbrand",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_catalog_CatalogTypes_CatalogTypeId",
                        x => x.CatalogTypeId,
                        "CatalogTypes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_catalog_CatalogBrandId",
                "catalog",
                "CatalogBrandId");

            migrationBuilder.CreateIndex(
                "IX_catalog_CatalogTypeId",
                "catalog",
                "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "catalog_brand_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_type_hilo");

            migrationBuilder.DropTable(
                name: "catalog");

            migrationBuilder.DropTable(
                name: "catalogbrand");

            migrationBuilder.DropTable(
                name: "CatalogTypes");
        }
    }
}
