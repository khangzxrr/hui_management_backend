using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSubUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundMember_Users_UserId",
                table: "FundMember");

            migrationBuilder.DropTable(
                name: "UserCreateBy");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BankNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdentityAddress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdentityCreateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdentityImageBackUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdentityImageFrontUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FundMember",
                newName: "subUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FundMember_UserId",
                table: "FundMember",
                newName: "IX_FundMember_subUserId");

            migrationBuilder.CreateTable(
                name: "SubUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rootUserId = table.Column<int>(type: "int", nullable: false),
                    createById = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2023, 8, 9, 19, 4, 19, 747, DateTimeKind.Unspecified).AddTicks(2775), new TimeSpan(0, 7, 0, 0, 0))),
                    IdentityAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityImageFrontUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityImageBackUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Chưa có nick name"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubUser_Users_createById",
                        column: x => x.createById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubUser_Users_rootUserId",
                        column: x => x.rootUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubUser_createById",
                table: "SubUser",
                column: "createById");

            migrationBuilder.CreateIndex(
                name: "IX_SubUser_rootUserId",
                table: "SubUser",
                column: "rootUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundMember_SubUser_subUserId",
                table: "FundMember",
                column: "subUserId",
                principalTable: "SubUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundMember_SubUser_subUserId",
                table: "FundMember");

            migrationBuilder.DropTable(
                name: "SubUser");

            migrationBuilder.RenameColumn(
                name: "subUserId",
                table: "FundMember",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FundMember_subUserId",
                table: "FundMember",
                newName: "IX_FundMember_UserId");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BankNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityAddress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 4, 18, 29, 36, 831, DateTimeKind.Unspecified).AddTicks(6114), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "IdentityImageBackUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityImageFrontUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Chưa có nick name");

            migrationBuilder.CreateTable(
                name: "UserCreateBy",
                columns: table => new
                {
                    CreateById = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCreateBy", x => new { x.CreateById, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserCreateBy_Users_CreateById",
                        column: x => x.CreateById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCreateBy_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCreateBy_UserId",
                table: "UserCreateBy",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundMember_Users_UserId",
                table: "FundMember",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
