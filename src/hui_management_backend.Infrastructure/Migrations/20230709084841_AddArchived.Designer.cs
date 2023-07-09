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
    [Migration("20230709084841_AddArchived")]
    partial class AddArchived
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("hui_management_backend.Core.ContributorAggregate.Contributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.Fund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("FundPrice")
                        .HasColumnType("float");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("OpenDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("OpenDateText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<double>("ServiceCost")
                        .HasColumnType("float");

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

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FundId");

                    b.HasIndex("UserId");

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

                    b.Property<DateTimeOffset>("TakenDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("FundId");

                    b.ToTable("FundSession");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.FundSessionDetail", b =>
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

                    b.Property<double>("ownerCost")
                        .HasColumnType("float");

                    b.Property<double>("predictedPrice")
                        .HasColumnType("float");

                    b.Property<double>("remainPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FundSessionId");

                    b.HasIndex("fundMemberId");

                    b.ToTable("FundSessionDetail");
                });

            modelBuilder.Entity("hui_management_backend.Core.ProjectAggregate.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("hui_management_backend.Core.ProjectAggregate.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ContributorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("hui_management_backend.Core.UserAggregate.User", b =>
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

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("User");
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

                    b.HasOne("hui_management_backend.Core.UserAggregate.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.FundSession", b =>
                {
                    b.HasOne("hui_management_backend.Core.FundAggregate.Fund", null)
                        .WithMany("Sessions")
                        .HasForeignKey("FundId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.FundSessionDetail", b =>
                {
                    b.HasOne("hui_management_backend.Core.FundAggregate.FundSession", null)
                        .WithMany("FundSessionDetails")
                        .HasForeignKey("FundSessionId");

                    b.HasOne("hui_management_backend.Core.FundAggregate.FundMember", "fundMember")
                        .WithMany()
                        .HasForeignKey("fundMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("fundMember");
                });

            modelBuilder.Entity("hui_management_backend.Core.ProjectAggregate.ToDoItem", b =>
                {
                    b.HasOne("hui_management_backend.Core.ProjectAggregate.Project", null)
                        .WithMany("Items")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.Fund", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("hui_management_backend.Core.FundAggregate.FundSession", b =>
                {
                    b.Navigation("FundSessionDetails");
                });

            modelBuilder.Entity("hui_management_backend.Core.ProjectAggregate.Project", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
