namespace Catalog.API.Infrastructure.IntegrationEventMigrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddTransactionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "TransactionId",
                "IntegrationEventLog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "TransactionId",
                "IntegrationEventLog");
        }
    }
}
