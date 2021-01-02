using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaSolution.Migrations
{
    public partial class diffusionPartner_password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DiffusionPartners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "DiffusionPartners",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "DiffusionPartners");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "DiffusionPartners");
        }
    }
}
