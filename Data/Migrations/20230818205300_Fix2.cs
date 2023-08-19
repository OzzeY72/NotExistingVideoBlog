using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotExistingVideoBlog.Data.Migrations
{
    public partial class Fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Author_AuthorId",
                table: "Video");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Video",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Author_AuthorId",
                table: "Video",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Author_AuthorId",
                table: "Video");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Author_AuthorId",
                table: "Video",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
