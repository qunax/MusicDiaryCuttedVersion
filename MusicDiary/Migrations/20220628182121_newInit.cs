using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDiary.Migrations
{
    public partial class newInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlbumTitle",
                table: "Tracks",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumTitle",
                table: "Tracks");
        }
    }
}
