using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    FundType = table.Column<int>(type: "int", nullable: false),
                    NewSessionDurationCount = table.Column<int>(type: "int", nullable: false),
                    TakenSessionDeliveryCount = table.Column<int>(type: "int", nullable: false),
                    NewSessionCreateDayOfMonth = table.Column<int>(type: "int", nullable: false),
                    NewSessionCreateHourOfDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TakenSessionDeliveryHourOfDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FundPrice = table.Column<double>(type: "float", nullable: false),
                    ServiceCost = table.Column<double>(type: "float", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funds_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rootUserId = table.Column<int>(type: "int", nullable: false),
                    createById = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 25, 20, 18, 32, 662, DateTimeKind.Local).AddTicks(3555)),
                    IdentityAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityImageFrontUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityImageBackUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Chưa có nick name"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubUser_Users_createById",
                        column: x => x.createById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubUser_Users_rootUserId",
                        column: x => x.rootUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    takenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sessionNumber = table.Column<int>(type: "int", nullable: false),
                    FundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundSession_Funds_FundId",
                        column: x => x.FundId,
                        principalTable: "Funds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_SubUser_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "SubUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "FundMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    replicationCount = table.Column<int>(type: "int", nullable: false),
                    subUserId = table.Column<int>(type: "int", nullable: false),
                    finalSettlementForDeadSessionBillId = table.Column<int>(type: "int", nullable: true),
                    FundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundMember_Funds_FundId",
                        column: x => x.FundId,
                        principalTable: "Funds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundMember_Payment_finalSettlementForDeadSessionBillId",
                        column: x => x.finalSettlementForDeadSessionBillId,
                        principalTable: "Payment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FundMember_SubUser_subUserId",
                        column: x => x.subUserId,
                        principalTable: "SubUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NormalSessionDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    predictedPrice = table.Column<double>(type: "float", nullable: false),
                    fundAmount = table.Column<double>(type: "float", nullable: false),
                    lossCost = table.Column<double>(type: "float", nullable: false),
                    serviceCost = table.Column<double>(type: "float", nullable: false),
                    payCost = table.Column<double>(type: "float", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    fundMemberId = table.Column<int>(type: "int", nullable: false),
                    FundSessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalSessionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NormalSessionDetail_FundMember_fundMemberId",
                        column: x => x.fundMemberId,
                        principalTable: "FundMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NormalSessionDetail_FundSession_FundSessionId",
                        column: x => x.FundSessionId,
                        principalTable: "FundSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentTransactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionImage_PaymentTransaction_PaymentTransactionId",
                        column: x => x.PaymentTransactionId,
                        principalTable: "PaymentTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundBill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fromFundId = table.Column<int>(type: "int", nullable: true),
                    fromSessionId = table.Column<int>(type: "int", nullable: true),
                    fromSessionDetailId = table.Column<int>(type: "int", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundBill_FundSession_fromSessionId",
                        column: x => x.fromSessionId,
                        principalTable: "FundSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundBill_Funds_fromFundId",
                        column: x => x.fromFundId,
                        principalTable: "Funds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundBill_NormalSessionDetail_fromSessionDetailId",
                        column: x => x.fromSessionDetailId,
                        principalTable: "NormalSessionDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundBill_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomBill_PaymentId",
                table: "CustomBill",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_FundBill_fromFundId",
                table: "FundBill",
                column: "fromFundId");

            migrationBuilder.CreateIndex(
                name: "IX_FundBill_fromSessionDetailId",
                table: "FundBill",
                column: "fromSessionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_FundBill_fromSessionId",
                table: "FundBill",
                column: "fromSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_FundBill_PaymentId",
                table: "FundBill",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_FundMember_finalSettlementForDeadSessionBillId",
                table: "FundMember",
                column: "finalSettlementForDeadSessionBillId");

            migrationBuilder.CreateIndex(
                name: "IX_FundMember_FundId",
                table: "FundMember",
                column: "FundId");

            migrationBuilder.CreateIndex(
                name: "IX_FundMember_subUserId",
                table: "FundMember",
                column: "subUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Funds_OwnerId",
                table: "Funds",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSession_FundId",
                table: "FundSession",
                column: "FundId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalSessionDetail_fundMemberId",
                table: "NormalSessionDetail",
                column: "fundMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalSessionDetail_FundSessionId",
                table: "NormalSessionDetail",
                column: "FundSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationToken_UserId",
                table: "NotificationToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OwnerId",
                table: "Payment",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_PaymentId",
                table: "PaymentTransaction",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubUser_createById",
                table: "SubUser",
                column: "createById");

            migrationBuilder.CreateIndex(
                name: "IX_SubUser_rootUserId_createById",
                table: "SubUser",
                columns: new[] { "rootUserId", "createById" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionImage_PaymentTransactionId",
                table: "TransactionImage",
                column: "PaymentTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomBill");

            migrationBuilder.DropTable(
                name: "FundBill");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "NotificationToken");

            migrationBuilder.DropTable(
                name: "TransactionImage");

            migrationBuilder.DropTable(
                name: "NormalSessionDetail");

            migrationBuilder.DropTable(
                name: "PaymentTransaction");

            migrationBuilder.DropTable(
                name: "FundMember");

            migrationBuilder.DropTable(
                name: "FundSession");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Funds");

            migrationBuilder.DropTable(
                name: "SubUser");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
