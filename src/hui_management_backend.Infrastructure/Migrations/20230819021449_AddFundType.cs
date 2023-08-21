using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFundType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TakenSessionDeliveryDayCount",
                table: "Funds",
                newName: "TakenSessionDeliveryCount");

            migrationBuilder.RenameColumn(
                name: "NewSessionDurationDayCount",
                table: "Funds",
                newName: "NewSessionDurationCount");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 19, 9, 14, 49, 53, DateTimeKind.Unspecified).AddTicks(2606), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 18, 18, 27, 20, 476, DateTimeKind.Unspecified).AddTicks(3662), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "FundType",
                table: "Funds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewSessionCreateDayOfMonth",
                table: "Funds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NewSessionCreateHourOfDay",
                table: "Funds",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FundType",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "NewSessionCreateDayOfMonth",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "NewSessionCreateHourOfDay",
                table: "Funds");

            migrationBuilder.RenameColumn(
                name: "TakenSessionDeliveryCount",
                table: "Funds",
                newName: "TakenSessionDeliveryDayCount");

            migrationBuilder.RenameColumn(
                name: "NewSessionDurationCount",
                table: "Funds",
                newName: "NewSessionDurationDayCount");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 18, 18, 27, 20, 476, DateTimeKind.Unspecified).AddTicks(3662), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 19, 9, 14, 49, 53, DateTimeKind.Unspecified).AddTicks(2606), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
