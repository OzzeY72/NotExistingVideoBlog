using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotExistingVideoBlog.Data.Migrations
{
    public partial class FixVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Video",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Preview",
                table: "Video",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Video",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Video",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "Preview",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Video");
        }
    }
}
