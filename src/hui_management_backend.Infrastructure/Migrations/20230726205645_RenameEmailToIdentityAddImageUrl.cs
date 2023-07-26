using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameEmailToIdentityAddImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundMember_User_UserId",
                table: "FundMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Funds_User_OwnerId",
                table: "Funds");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_User_OwnerId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCreateBy_User_CreateById",
                table: "UserCreateBy");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCreateBy_User_UserId",
                table: "UserCreateBy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "ImageUrl");

            migrationBuilder.RenameIndex(
                name: "IX_User_PhoneNumber",
                table: "Users",
                newName: "IX_Users_PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FundMember_Users_UserId",
                table: "FundMember",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funds_Users_OwnerId",
                table: "Funds",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Users_OwnerId",
                table: "Payment",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCreateBy_Users_CreateById",
                table: "UserCreateBy",
                column: "CreateById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCreateBy_Users_UserId",
                table: "UserCreateBy",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundMember_Users_UserId",
                table: "FundMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Funds_Users_OwnerId",
                table: "Funds");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Users_OwnerId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCreateBy_Users_CreateById",
                table: "UserCreateBy");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCreateBy_Users_UserId",
                table: "UserCreateBy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Identity",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "User",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PhoneNumber",
                table: "User",
                newName: "IX_User_PhoneNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FundMember_User_UserId",
                table: "FundMember",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funds_User_OwnerId",
                table: "Funds",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_User_OwnerId",
                table: "Payment",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
