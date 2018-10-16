using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelConnect.Data.Migrations
{
    public partial class TripModelUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TripDescription",
                table: "TripModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripDescription",
                table: "TripModel");
        }
    }
}
