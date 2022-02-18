using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerApp.DAL_.Migrations
{
    public partial class AddArmor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Armor",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Armor",
                table: "Heroes");
        }
    }
}
