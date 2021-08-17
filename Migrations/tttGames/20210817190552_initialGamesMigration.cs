using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tttServer.Migrations.tttGames
{
    public partial class initialGamesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblGames",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Participant = table.Column<int>(nullable: false),
                    Num_of_turns = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    User_win = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGames", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblGames");
        }
    }
}
