using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CascadeFundBills2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NormalSessionDetail_FundMember_fundMemberId",
                table: "NormalSessionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_NormalSessionDetail_FundSession_FundSessionId",
                table: "NormalSessionDetail");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 44, 29, 163, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 38, 40, 250, DateTimeKind.Unspecified).AddTicks(6365), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_NormalSessionDetail_FundMember_fundMemberId",
                table: "NormalSessionDetail",
                column: "fundMemberId",
                principalTable: "FundMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NormalSessionDetail_FundSession_FundSessionId",
                table: "NormalSessionDetail",
                column: "FundSessionId",
                principalTable: "FundSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NormalSessionDetail_FundMember_fundMemberId",
                table: "NormalSessionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_NormalSessionDetail_FundSession_FundSessionId",
                table: "NormalSessionDetail");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 38, 40, 250, DateTimeKind.Unspecified).AddTicks(6365), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 44, 29, 163, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_NormalSessionDetail_FundMember_fundMemberId",
                table: "NormalSessionDetail",
                column: "fundMemberId",
                principalTable: "FundMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NormalSessionDetail_FundSession_FundSessionId",
                table: "NormalSessionDetail",
                column: "FundSessionId",
                principalTable: "FundSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
