using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TomasosPizzeria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderUpdate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusStr",
                schema: "identity",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusStr",
                schema: "identity",
                table: "Orders");
        }
    }
}
