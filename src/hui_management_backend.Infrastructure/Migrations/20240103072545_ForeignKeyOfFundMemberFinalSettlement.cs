using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyOfFundMemberFinalSettlement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundMember_Payment_finalSettlementForDeadSessionBillId",
                table: "FundMember");

            migrationBuilder.DropIndex(
                name: "IX_FundMember_finalSettlementForDeadSessionBillId",
                table: "FundMember");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 3, 14, 25, 45, 175, DateTimeKind.Local).AddTicks(7660),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 31, 2, 8, 54, 341, DateTimeKind.Local).AddTicks(819));

            migrationBuilder.CreateIndex(
                name: "IX_FundMember_finalSettlementForDeadSessionBillId",
                table: "FundMember",
                column: "finalSettlementForDeadSessionBillId",
                unique: true,
                filter: "[finalSettlementForDeadSessionBillId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_FundMember_Payment_finalSettlementForDeadSessionBillId",
                table: "FundMember",
                column: "finalSettlementForDeadSessionBillId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundMember_Payment_finalSettlementForDeadSessionBillId",
                table: "FundMember");

            migrationBuilder.DropIndex(
                name: "IX_FundMember_finalSettlementForDeadSessionBillId",
                table: "FundMember");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 31, 2, 8, 54, 341, DateTimeKind.Local).AddTicks(819),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 3, 14, 25, 45, 175, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.CreateIndex(
                name: "IX_FundMember_finalSettlementForDeadSessionBillId",
                table: "FundMember",
                column: "finalSettlementForDeadSessionBillId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundMember_Payment_finalSettlementForDeadSessionBillId",
                table: "FundMember",
                column: "finalSettlementForDeadSessionBillId",
                principalTable: "Payment",
                principalColumn: "Id");
        }
    }
}
