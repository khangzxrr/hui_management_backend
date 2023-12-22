using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetNullFundBills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_FundSession_fromSessionId",
                table: "FundBill");

            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_Funds_fromFundId",
                table: "FundBill");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 22, 1, 0, 37, 632, DateTimeKind.Local).AddTicks(136),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 22, 0, 53, 54, 58, DateTimeKind.Local).AddTicks(8902));

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_FundSession_fromSessionId",
                table: "FundBill",
                column: "fromSessionId",
                principalTable: "FundSession",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_Funds_fromFundId",
                table: "FundBill",
                column: "fromFundId",
                principalTable: "Funds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_FundSession_fromSessionId",
                table: "FundBill");

            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_Funds_fromFundId",
                table: "FundBill");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 22, 0, 53, 54, 58, DateTimeKind.Local).AddTicks(8902),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 22, 1, 0, 37, 632, DateTimeKind.Local).AddTicks(136));

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_FundSession_fromSessionId",
                table: "FundBill",
                column: "fromSessionId",
                principalTable: "FundSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_Funds_fromFundId",
                table: "FundBill",
                column: "fromFundId",
                principalTable: "Funds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
