using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteFundBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                defaultValue: new DateTime(2023, 12, 22, 0, 53, 54, 58, DateTimeKind.Local).AddTicks(8902),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 25, 20, 18, 32, 662, DateTimeKind.Local).AddTicks(3555));

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_Funds_fromFundId",
                table: "FundBill",
                column: "fromFundId",
                principalTable: "Funds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundBill_NormalSessionDetail_fromSessionDetailId",
                table: "FundBill",
                column: "fromSessionDetailId",
                principalTable: "NormalSessionDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                defaultValue: new DateTime(2023, 11, 25, 20, 18, 32, 662, DateTimeKind.Local).AddTicks(3555),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 22, 0, 53, 54, 58, DateTimeKind.Local).AddTicks(8902));

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
    }
}
