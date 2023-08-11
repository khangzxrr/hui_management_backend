using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CascadePaymentFundBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_Payment_PaymentId",
                table: "FundBill");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 49, 12, 872, DateTimeKind.Unspecified).AddTicks(9525), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 44, 29, 163, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_Payment_PaymentId",
                table: "FundBill",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_Payment_PaymentId",
                table: "FundBill");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 44, 29, 163, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 49, 12, 872, DateTimeKind.Unspecified).AddTicks(9525), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_Payment_PaymentId",
                table: "FundBill",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
