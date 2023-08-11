using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFundBillFromSesion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundBill_FundSession_FundSessionId",
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
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 20, 1, 50, 158, DateTimeKind.Unspecified).AddTicks(7298), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 49, 12, 872, DateTimeKind.Unspecified).AddTicks(9525), new TimeSpan(0, 7, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 19, 49, 12, 872, DateTimeKind.Unspecified).AddTicks(9525), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 20, 1, 50, 158, DateTimeKind.Unspecified).AddTicks(7298), new TimeSpan(0, 7, 0, 0, 0)));

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
