using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelConnect.Data.Migrations
{
    public partial class Messages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "MessagesModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "MessagesModel");
        }
    }
}
