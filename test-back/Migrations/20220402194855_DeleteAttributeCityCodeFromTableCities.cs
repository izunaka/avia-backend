using Microsoft.EntityFrameworkCore.Migrations;

namespace test_back.Migrations
{
    public partial class DeleteAttributeCityCodeFromTableCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "Cities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityCode",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
