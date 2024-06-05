using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TomasosPizzeria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Discount",
                schema: "identity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                schema: "identity",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "identity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Score",
                schema: "identity",
                table: "AspNetUsers");
        }
    }
}
