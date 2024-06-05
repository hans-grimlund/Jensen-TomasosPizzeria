using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TomasosPizzeria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderUpdate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusStr",
                schema: "identity",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "identity",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "identity",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "StatusStr",
                schema: "identity",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
