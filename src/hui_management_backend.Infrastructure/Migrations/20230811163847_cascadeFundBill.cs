using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cascadeFundBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundMember_Funds_FundId",
                table: "FundMember");

            migrationBuilder.DropForeignKey(
                name: "FK_NormalSessionDetail_FundMember_fundMemberId",
                table: "NormalSessionDetail");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 23, 38, 47, 627, DateTimeKind.Unspecified).AddTicks(4120), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 22, 21, 9, 834, DateTimeKind.Unspecified).AddTicks(610), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_FundMember_Funds_FundId",
                table: "FundMember",
                column: "FundId",
                principalTable: "Funds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NormalSessionDetail_FundMember_fundMemberId",
                table: "NormalSessionDetail",
                column: "fundMemberId",
                principalTable: "FundMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundMember_Funds_FundId",
                table: "FundMember");

            migrationBuilder.DropForeignKey(
                name: "FK_NormalSessionDetail_FundMember_fundMemberId",
                table: "NormalSessionDetail");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 22, 21, 9, 834, DateTimeKind.Unspecified).AddTicks(610), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 23, 38, 47, 627, DateTimeKind.Unspecified).AddTicks(4120), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_FundMember_Funds_FundId",
                table: "FundMember",
                column: "FundId",
                principalTable: "Funds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NormalSessionDetail_FundMember_fundMemberId",
                table: "NormalSessionDetail",
                column: "fundMemberId",
                principalTable: "FundMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
