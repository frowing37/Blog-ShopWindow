using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Data.Migrations
{
    /// <inheritdoc />
    public partial class mig08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductNumberofPoint",
                table: "products");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPoint",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductPoint",
                table: "products",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "ProductNumberofPoint",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
