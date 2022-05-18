using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lw7.Data.Migrations
{
    public partial class adddeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "developer",
                table: "game");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "game",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "game",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "game",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "developer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developer", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_game_DeveloperId",
                table: "game",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_game_developer_DeveloperId",
                table: "game",
                column: "DeveloperId",
                principalTable: "developer",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_game_developer_DeveloperId",
                table: "game");

            migrationBuilder.DropTable(
                name: "developer");

            migrationBuilder.DropIndex(
                name: "IX_game_DeveloperId",
                table: "game");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "game");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "game",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "game",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "developer",
                table: "game",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
