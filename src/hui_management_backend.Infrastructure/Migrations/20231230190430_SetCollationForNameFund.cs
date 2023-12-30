using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetCollationForNameFund : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 31, 2, 4, 30, 293, DateTimeKind.Local).AddTicks(7032),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 25, 0, 19, 52, 558, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Funds",
                type: "nvarchar(max)",
                nullable: false,
                collation: "VIETNAMESE_CI_AI",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 25, 0, 19, 52, 558, DateTimeKind.Local).AddTicks(1392),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 31, 2, 4, 30, 293, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Funds",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldCollation: "VIETNAMESE_CI_AI");
        }
    }
}
