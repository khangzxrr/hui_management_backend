using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomBills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payment_CreateAt",
                table: "Payment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 22, 13, 11, 40, 763, DateTimeKind.Local).AddTicks(4531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 18, 0, 32, 19, 348, DateTimeKind.Local).AddTicks(6609));

            migrationBuilder.AddColumn<int>(
                name: "finalSettlementForDeadSessionBillId",
                table: "FundMember",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomBill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payCost = table.Column<double>(type: "float", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomBill_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundMember_finalSettlementForDeadSessionBillId",
                table: "FundMember",
                column: "finalSettlementForDeadSessionBillId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomBill_PaymentId",
                table: "CustomBill",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundMember_Payment_finalSettlementForDeadSessionBillId",
                table: "FundMember",
                column: "finalSettlementForDeadSessionBillId",
                principalTable: "Payment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundMember_Payment_finalSettlementForDeadSessionBillId",
                table: "FundMember");

            migrationBuilder.DropTable(
                name: "CustomBill");

            migrationBuilder.DropIndex(
                name: "IX_FundMember_finalSettlementForDeadSessionBillId",
                table: "FundMember");

            migrationBuilder.DropColumn(
                name: "finalSettlementForDeadSessionBillId",
                table: "FundMember");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 18, 0, 32, 19, 348, DateTimeKind.Local).AddTicks(6609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 22, 13, 11, 40, 763, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CreateAt",
                table: "Payment",
                column: "CreateAt",
                unique: true);
        }
    }
}
