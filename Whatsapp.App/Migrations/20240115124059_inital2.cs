using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Whatsapp.App.Migrations
{
    public partial class inital2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectiionId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectiionId",
                table: "AspNetUsers");
        }
    }
}
