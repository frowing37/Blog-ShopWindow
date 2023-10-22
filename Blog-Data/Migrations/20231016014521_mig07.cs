using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Data.Migrations
{
    /// <inheritdoc />
    public partial class mig07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostName",
                table: "posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommentName",
                table: "comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CommentNumberofLike",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostName",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "CommentName",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "CommentNumberofLike",
                table: "comments");
        }
    }
}
