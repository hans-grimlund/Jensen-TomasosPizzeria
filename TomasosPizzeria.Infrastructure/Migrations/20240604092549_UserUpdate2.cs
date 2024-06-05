using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TomasosPizzeria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                schema: "identity",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                schema: "identity",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "identity",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "identity",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                schema: "identity",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                schema: "identity",
                table: "Orders",
                column: "ApplicationUserId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                schema: "identity",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ApplicationUserId",
                schema: "identity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "identity",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "identity",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                schema: "identity",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                schema: "identity",
                table: "Orders",
                column: "UserId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
