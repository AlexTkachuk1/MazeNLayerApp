using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerApp.DAL_.Migrations
{
    public partial class rmoveOneToManyRelayionshipBetweenUserAndMaze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mazes_Users_CreaterId",
                table: "Mazes");

            migrationBuilder.DropIndex(
                name: "IX_Mazes_CreaterId",
                table: "Mazes");

            migrationBuilder.DropColumn(
                name: "CreaterId",
                table: "Mazes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreaterId",
                table: "Mazes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mazes_CreaterId",
                table: "Mazes",
                column: "CreaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mazes_Users_CreaterId",
                table: "Mazes",
                column: "CreaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
