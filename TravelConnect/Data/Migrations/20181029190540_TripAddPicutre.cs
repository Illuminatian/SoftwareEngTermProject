using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelConnect.Data.Migrations
{
    public partial class TripAddPicutre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomPictureId",
                table: "TripModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomPictureId",
                table: "TripModel");
        }
    }
}
