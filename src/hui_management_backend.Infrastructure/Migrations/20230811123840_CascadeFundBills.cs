using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CascadeFundBills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_FundSession_FundSessionId",
                table: "FundBill");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 38, 40, 250, DateTimeKind.Unspecified).AddTicks(6365), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 37, 53, 915, DateTimeKind.Unspecified).AddTicks(3264), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_FundSession_FundSessionId",
                table: "FundBill",
                column: "FundSessionId",
                principalTable: "FundSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_FundSession_FundSessionId",
                table: "FundBill");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 37, 53, 915, DateTimeKind.Unspecified).AddTicks(3264), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 38, 40, 250, DateTimeKind.Unspecified).AddTicks(6365), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_FundSession_FundSessionId",
                table: "FundBill",
                column: "FundSessionId",
                principalTable: "FundSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
