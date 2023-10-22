using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Data.Migrations
{
    /// <inheritdoc />
    public partial class mig09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductPoint",
                table: "products",
                newName: "ProductPrice");

            migrationBuilder.AddColumn<int>(
                name: "NumberofLike",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberofLike",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "products",
                newName: "ProductPoint");
        }
    }
}
