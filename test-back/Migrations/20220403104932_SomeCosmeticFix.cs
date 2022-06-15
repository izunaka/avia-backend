using Microsoft.EntityFrameworkCore.Migrations;

namespace test_back.Migrations
{
    public partial class SomeCosmeticFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isRefundable",
                table: "Tickets",
                newName: "IsRefundable");

            migrationBuilder.RenameColumn(
                name: "isRefund",
                table: "Passengers",
                newName: "IsRefund");

            migrationBuilder.RenameColumn(
                name: "citizenship",
                table: "Passengers",
                newName: "Citizenship");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRefundable",
                table: "Tickets",
                newName: "isRefundable");

            migrationBuilder.RenameColumn(
                name: "IsRefund",
                table: "Passengers",
                newName: "isRefund");

            migrationBuilder.RenameColumn(
                name: "Citizenship",
                table: "Passengers",
                newName: "citizenship");
        }
    }
}
