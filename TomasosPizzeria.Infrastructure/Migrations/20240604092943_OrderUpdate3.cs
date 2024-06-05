using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TomasosPizzeria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                schema: "identity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "identity",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                schema: "identity",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                schema: "identity",
                table: "Orders",
                column: "ApplicationUserId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                schema: "identity",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                schema: "identity",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "identity",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                schema: "identity",
                table: "Orders",
                column: "ApplicationUserId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
