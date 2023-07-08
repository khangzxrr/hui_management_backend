using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFundMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundMember");

            migrationBuilder.AddColumn<int>(
                name: "FundId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_FundId",
                table: "User",
                column: "FundId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Funds_FundId",
                table: "User",
                column: "FundId",
                principalTable: "Funds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Funds_FundId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_FundId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FundId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "FundMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FundId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundMember_Funds_FundId",
                        column: x => x.FundId,
                        principalTable: "Funds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FundMember_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundMember_FundId",
                table: "FundMember",
                column: "FundId");

            migrationBuilder.CreateIndex(
                name: "IX_FundMember_UserId",
                table: "FundMember",
                column: "UserId");
        }
    }
}
