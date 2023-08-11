using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameNickNameToReplicationCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "FundMember",
                newName: "replicationCount");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 20, 23, 32, 247, DateTimeKind.Unspecified).AddTicks(8621), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 20, 1, 50, 158, DateTimeKind.Unspecified).AddTicks(7298), new TimeSpan(0, 7, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "replicationCount",
                table: "FundMember",
                newName: "NickName");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "IdentityCreateDate",
                table: "SubUser",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 20, 1, 50, 158, DateTimeKind.Unspecified).AddTicks(7298), new TimeSpan(0, 7, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2023, 8, 11, 20, 23, 32, 247, DateTimeKind.Unspecified).AddTicks(8621), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
