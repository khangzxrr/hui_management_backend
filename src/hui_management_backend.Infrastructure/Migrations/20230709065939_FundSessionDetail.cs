using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FundSessionDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundSession_FundMember_FundMemberId",
                table: "FundSession");

            migrationBuilder.DropIndex(
                name: "IX_FundSession_FundMemberId",
                table: "FundSession");

            migrationBuilder.DropColumn(
                name: "FundAmount",
                table: "FundSession");

            migrationBuilder.DropColumn(
                name: "FundMemberId",
                table: "FundSession");

            migrationBuilder.DropColumn(
                name: "PredictPrice",
                table: "FundSession");

            migrationBuilder.DropColumn(
                name: "RemainPrice",
                table: "FundSession");

            migrationBuilder.CreateTable(
                name: "FundSessionDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fundMemberId = table.Column<int>(type: "int", nullable: false),
                    predictedPrice = table.Column<double>(type: "float", nullable: false),
                    fundAmount = table.Column<double>(type: "float", nullable: false),
                    remainPrice = table.Column<double>(type: "float", nullable: false),
                    ownerCost = table.Column<double>(type: "float", nullable: false),
                    FundSessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundSessionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundSessionDetail_FundMember_fundMemberId",
                        column: x => x.fundMemberId,
                        principalTable: "FundMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundSessionDetail_FundSession_FundSessionId",
                        column: x => x.FundSessionId,
                        principalTable: "FundSession",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundSessionDetail_fundMemberId",
                table: "FundSessionDetail",
                column: "fundMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSessionDetail_FundSessionId",
                table: "FundSessionDetail",
                column: "FundSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundSessionDetail");

            migrationBuilder.AddColumn<double>(
                name: "FundAmount",
                table: "FundSession",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "FundMemberId",
                table: "FundSession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PredictPrice",
                table: "FundSession",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RemainPrice",
                table: "FundSession",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_FundSession_FundMemberId",
                table: "FundSession",
                column: "FundMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundSession_FundMember_FundMemberId",
                table: "FundSession",
                column: "FundMemberId",
                principalTable: "FundMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
