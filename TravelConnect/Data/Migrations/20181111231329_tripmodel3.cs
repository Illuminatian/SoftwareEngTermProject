using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelConnect.Data.Migrations
{
    public partial class tripmodel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TripDescription",
                table: "TripModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DestinationCity",
                table: "TripModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartureCity",
                table: "TripModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TripDescription",
                table: "TripModel",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DestinationCity",
                table: "TripModel",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DepartureCity",
                table: "TripModel",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
