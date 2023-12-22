﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hui_management_backend.Infrastructure.Data;

#nullable disable

namespace hui_management_backend.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231221180037_SetNullFundBills")]
    partial class SetNullFundBills
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.Fund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("FundPrice")
                        .HasColumnType("float");

                    b.Property<int>("FundType")
                        .HasColumnType("int");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NewSessionCreateDayOfMonth")
                        .HasColumnType("int");

                    b.Property<DateTime>("NewSessionCreateHourOfDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("NewSessionDurationCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<double>("ServiceCost")
                        .HasColumnType("float");

                    b.Property<int>("TakenSessionDeliveryCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("TakenSessionDeliveryHourOfDay")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Funds");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.FundMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FundId")
                        .HasColumnType("int");

                    b.Property<int?>("finalSettlementForDeadSessionBillId")
                        .HasColumnType("int");

                    b.Property<int>("replicationCount")
                        .HasColumnType("int");

                    b.Property<int>("subUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FundId");

                    b.HasIndex("finalSettlementForDeadSessionBillId");

                    b.HasIndex("subUserId");

                    b.ToTable("FundMember");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.FundSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FundId")
                        .HasColumnType("int");

                    b.Property<int>("sessionNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("takenDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FundId");

                    b.ToTable("FundSession");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.NormalSessionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FundSessionId")
                        .HasColumnType("int");

                    b.Property<double>("fundAmount")
                        .HasColumnType("float");

                    b.Property<int>("fundMemberId")
                        .HasColumnType("int");

                    b.Property<double>("lossCost")
                        .HasColumnType("float");

                    b.Property<double>("payCost")
                        .HasColumnType("float");

                    b.Property<double>("predictedPrice")
                        .HasColumnType("float");

                    b.Property<double>("serviceCost")
                        .HasColumnType("float");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FundSessionId");

                    b.HasIndex("fundMemberId");

                    b.ToTable("NormalSessionDetail");
                });

            modelBuilder.Entity("hui_management_backend.Core.MediaAggregate.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.CustomBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("payCost")
                        .HasColumnType("float");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("CustomBill");
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.FundBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int?>("fromFundId")
                        .HasColumnType("int");

                    b.Property<int?>("fromSessionDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("fromSessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("fromFundId");

                    b.HasIndex("fromSessionDetailId");

                    b.HasIndex("fromSessionId");

                    b.ToTable("FundBill");
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.PaymentTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("PaymentTransaction");
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.TransactionImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentTransactionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTransactionId");

                    b.ToTable("TransactionImage");
                });

            modelBuilder.Entity("hui_management_backend.Core.UserAggregate.NotificationToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("NotificationToken");
                });

            modelBuilder.Entity("hui_management_backend.Core.UserAggregate.SubUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IdentityCreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 22, 1, 0, 37, 632, DateTimeKind.Local).AddTicks(136));

                    b.Property<string>("IdentityImageBackUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityImageFrontUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Chưa có nick name");

                    b.Property<int>("createById")
                        .HasColumnType("int");

                    b.Property<int>("rootUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("createById");

                    b.HasIndex("rootUserId", "createById")
                        .IsUnique();

                    b.ToTable("SubUser");
                });

            modelBuilder.Entity("hui_management_backend.Core.UserAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.Fund", b =>
                {
                    b.HasOne("hui_management_backend.Core.UserAggregate.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.FundMember", b =>
                {
                    b.HasOne("hui_management_backend.Core.FundAggregate.Fund", null)
                        .WithMany("Members")
                        .HasForeignKey("FundId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("hui_management_backend.Core.PaymentAggregate.Payment", "finalSettlementForDeadSessionBill")
                        .WithMany()
                        .HasForeignKey("finalSettlementForDeadSessionBillId");

                    b.HasOne("hui_management_backend.Core.UserAggregate.SubUser", "subUser")
                        .WithMany()
                        .HasForeignKey("subUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("finalSettlementForDeadSessionBill");

                    b.Navigation("subUser");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.FundSession", b =>
                {
                    b.HasOne("hui_management_backend.Core.FundAggregate.Fund", null)
                        .WithMany("Sessions")
                        .HasForeignKey("FundId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.NormalSessionDetail", b =>
                {
                    b.HasOne("hui_management_backend.Core.FundAggregate.FundSession", null)
                        .WithMany("normalSessionDetails")
                        .HasForeignKey("FundSessionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hui_management_backend.Core.FundAggregate.FundMember", "fundMember")
                        .WithMany()
                        .HasForeignKey("fundMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("fundMember");
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.CustomBill", b =>
                {
                    b.HasOne("hui_management_backend.Core.PaymentAggregate.Payment", null)
                        .WithMany("customBills")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.FundBill", b =>
                {
                    b.HasOne("hui_management_backend.Core.PaymentAggregate.Payment", null)
                        .WithMany("fundBills")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hui_management_backend.Core.FundAggregate.Fund", "fromFund")
                        .WithMany()
                        .HasForeignKey("fromFundId");

                    b.HasOne("hui_management_backend.Core.FundAggregate.NormalSessionDetail", "fromSessionDetail")
                        .WithMany()
                        .HasForeignKey("fromSessionDetailId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hui_management_backend.Core.FundAggregate.FundSession", "fromSession")
                        .WithMany()
                        .HasForeignKey("fromSessionId");

                    b.Navigation("fromFund");

                    b.Navigation("fromSession");

                    b.Navigation("fromSessionDetail");
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.Payment", b =>
                {
                    b.HasOne("hui_management_backend.Core.UserAggregate.SubUser", "Owner")
                        .WithMany("Payments")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.PaymentTransaction", b =>
                {
                    b.HasOne("hui_management_backend.Core.PaymentAggregate.Payment", null)
                        .WithMany("paymentTransactions")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.TransactionImage", b =>
                {
                    b.HasOne("hui_management_backend.Core.PaymentAggregate.PaymentTransaction", null)
                        .WithMany("transactionImages")
                        .HasForeignKey("PaymentTransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("hui_management_backend.Core.UserAggregate.NotificationToken", b =>
                {
                    b.HasOne("hui_management_backend.Core.UserAggregate.User", null)
                        .WithMany("NotificationTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("hui_management_backend.Core.UserAggregate.SubUser", b =>
                {
                    b.HasOne("hui_management_backend.Core.UserAggregate.User", "createBy")
                        .WithMany()
                        .HasForeignKey("createById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("hui_management_backend.Core.UserAggregate.User", "rootUser")
                        .WithMany("SubUsers")
                        .HasForeignKey("rootUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("createBy");

                    b.Navigation("rootUser");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.Fund", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.FundSession", b =>
                {
                    b.Navigation("normalSessionDetails");
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.Payment", b =>
                {
                    b.Navigation("customBills");

                    b.Navigation("fundBills");

                    b.Navigation("paymentTransactions");
                });

            modelBuilder.Entity("hui_management_backend.Core.PaymentAggregate.PaymentTransaction", b =>
                {
                    b.Navigation("transactionImages");
                });

            modelBuilder.Entity("hui_management_backend.Core.UserAggregate.SubUser", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("hui_management_backend.Core.UserAggregate.User", b =>
                {
                    b.Navigation("NotificationTokens");

                    b.Navigation("SubUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
