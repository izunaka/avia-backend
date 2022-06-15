using Microsoft.EntityFrameworkCore.Migrations;

namespace test_back.Migrations
{
    public partial class ChangeTypeAttributeFromCityToCityInTableTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromCity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ToCity",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "FromCityId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToCityId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FromCityId",
                table: "Tickets",
                column: "FromCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ToCityId",
                table: "Tickets",
                column: "ToCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Cities_FromCityId",
                table: "Tickets",
                column: "FromCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Cities_ToCityId",
                table: "Tickets",
                column: "ToCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Cities_FromCityId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Cities_ToCityId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FromCityId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ToCityId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FromCityId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ToCityId",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "FromCity",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToCity",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
