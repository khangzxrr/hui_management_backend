using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 4, 14, 32, 23, 727, DateTimeKind.Unspecified).AddTicks(7116), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 7, 29, 6, 2, 21, 903, DateTimeKind.Unspecified).AddTicks(7955), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddColumn<double>(
                name: "lossCost",
                table: "NormalSessionDetail",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lossCost",
                table: "NormalSessionDetail");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 7, 29, 6, 2, 21, 903, DateTimeKind.Unspecified).AddTicks(7955), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 4, 14, 32, 23, 727, DateTimeKind.Unspecified).AddTicks(7116), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
