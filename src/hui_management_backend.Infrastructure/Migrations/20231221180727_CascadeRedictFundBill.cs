using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CascadeRedictFundBill : Migration
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

            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_NormalSessionDetail_fromSessionDetailId",
                table: "FundBill");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 22, 1, 7, 27, 491, DateTimeKind.Local).AddTicks(4309),
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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_NormalSessionDetail_fromSessionDetailId",
                table: "FundBill",
                column: "fromSessionDetailId",
                principalTable: "NormalSessionDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_NormalSessionDetail_fromSessionDetailId",
                table: "FundBill");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 22, 1, 0, 37, 632, DateTimeKind.Local).AddTicks(136),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 22, 1, 7, 27, 491, DateTimeKind.Local).AddTicks(4309));

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

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_NormalSessionDetail_fromSessionDetailId",
                table: "FundBill",
                column: "fromSessionDetailId",
                principalTable: "NormalSessionDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
