using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotExistingVideoBlog.Data.Migrations
{
    public partial class AddA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_AuthorId",
                table: "Video",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Author_AuthorId",
                table: "Video",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Author_AuthorId",
                table: "Video");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Video_AuthorId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Video");
        }
    }
}
