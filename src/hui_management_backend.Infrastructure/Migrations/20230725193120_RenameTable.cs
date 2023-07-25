using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_User_CreateById",
                table: "UserUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_User_UserId",
                table: "UserUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUser",
                table: "UserUser");

            migrationBuilder.RenameTable(
                name: "UserUser",
                newName: "UserCreateBy");

            migrationBuilder.RenameIndex(
                name: "IX_UserUser_UserId",
                table: "UserCreateBy",
                newName: "IX_UserCreateBy_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCreateBy",
                table: "UserCreateBy",
                columns: new[] { "CreateById", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCreateBy_User_CreateById",
                table: "UserCreateBy",
                column: "CreateById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCreateBy_User_UserId",
                table: "UserCreateBy",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCreateBy_User_CreateById",
                table: "UserCreateBy");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCreateBy_User_UserId",
                table: "UserCreateBy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCreateBy",
                table: "UserCreateBy");

            migrationBuilder.RenameTable(
                name: "UserCreateBy",
                newName: "UserUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserCreateBy_UserId",
                table: "UserUser",
                newName: "IX_UserUser_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUser",
                table: "UserUser",
                columns: new[] { "CreateById", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_User_CreateById",
                table: "UserUser",
                column: "CreateById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_User_UserId",
                table: "UserUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
