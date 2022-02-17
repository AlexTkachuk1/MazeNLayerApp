using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerApp.DAL_.Migrations
{
    public partial class AddBaseEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cell_Mazes_MazeId",
                table: "Cell");

            migrationBuilder.DropForeignKey(
                name: "FK_Mazes_Heroes_HeroId",
                table: "Mazes");

            migrationBuilder.DropIndex(
                name: "IX_Mazes_HeroId",
                table: "Mazes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cell",
                table: "Cell");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Mazes");

            migrationBuilder.RenameTable(
                name: "Cell",
                newName: "Cells");

            migrationBuilder.RenameIndex(
                name: "IX_Cell_MazeId",
                table: "Cells",
                newName: "IX_Cells_MazeId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Mazes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MazeId",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cells",
                table: "Cells",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_MazeId",
                table: "Heroes",
                column: "MazeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Mazes_MazeId",
                table: "Cells",
                column: "MazeId",
                principalTable: "Mazes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Mazes_MazeId",
                table: "Heroes",
                column: "MazeId",
                principalTable: "Mazes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Mazes_MazeId",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Mazes_MazeId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_MazeId",
                table: "Heroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cells",
                table: "Cells");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Mazes");

            migrationBuilder.DropColumn(
                name: "MazeId",
                table: "Heroes");

            migrationBuilder.RenameTable(
                name: "Cells",
                newName: "Cell");

            migrationBuilder.RenameIndex(
                name: "IX_Cells_MazeId",
                table: "Cell",
                newName: "IX_Cell_MazeId");

            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Mazes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cell",
                table: "Cell",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mazes_HeroId",
                table: "Mazes",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cell_Mazes_MazeId",
                table: "Cell",
                column: "MazeId",
                principalTable: "Mazes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mazes_Heroes_HeroId",
                table: "Mazes",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
