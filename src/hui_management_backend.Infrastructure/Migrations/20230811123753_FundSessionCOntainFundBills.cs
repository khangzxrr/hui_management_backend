using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FundSessionCOntainFundBills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_FundSession_fromSessionId",
                table: "FundBill");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 37, 53, 915, DateTimeKind.Unspecified).AddTicks(3264), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 10, 3, 48, 44, 519, DateTimeKind.Unspecified).AddTicks(5452), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "FundSessionId",
                table: "FundBill",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FundBill_FundSessionId",
                table: "FundBill",
                column: "FundSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_FundSession_FundSessionId",
                table: "FundBill",
                column: "FundSessionId",
                principalTable: "FundSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_FundSession_fromSessionId",
                table: "FundBill",
                column: "fromSessionId",
                principalTable: "FundSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_FundSession_FundSessionId",
                table: "FundBill");

            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_FundSession_fromSessionId",
                table: "FundBill");

            migrationBuilder.DropIndex(
                name: "IX_FundBill_FundSessionId",
                table: "FundBill");

            migrationBuilder.DropColumn(
                name: "FundSessionId",
                table: "FundBill");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 10, 3, 48, 44, 519, DateTimeKind.Unspecified).AddTicks(5452), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 37, 53, 915, DateTimeKind.Unspecified).AddTicks(3264), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_FundSession_fromSessionId",
                table: "FundBill",
                column: "fromSessionId",
                principalTable: "FundSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
