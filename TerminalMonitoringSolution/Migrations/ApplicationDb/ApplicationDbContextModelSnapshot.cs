﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TerminalMonitoringSolution.DataAccess;

#nullable disable

namespace TerminalMonitoringSolution.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TerminalMonitoringSolution.Entities.Custodian", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ANM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cluster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClusterCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClusterManager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateActivated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IncomeAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LGA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Custodians");

                    b.HasData(
                        new
                        {
                            Id = "C001",
                            ANM = "ANM1",
                            Address = "123 Main St",
                            Cluster = "Cluster1",
                            ClusterCode = "CC001",
                            ClusterManager = "Manager1",
                            ContactNumber = "123-456-7890",
                            DateActivated = new DateTime(2024, 9, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1654),
                            DateCreated = new DateTime(2024, 8, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1588),
                            Email = "john.doe@example.com",
                            Gender = 1,
                            IncomeAccount = "IA001",
                            LGA = "LGA1",
                            Name = "John Doe",
                            State = "State1",
                            Status = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = "C002",
                            ANM = "ANM2",
                            Address = "456 Elm St",
                            Cluster = "Cluster2",
                            ClusterCode = "CC002",
                            ClusterManager = "Manager2",
                            ContactNumber = "098-765-4321",
                            DateActivated = new DateTime(2024, 8, 27, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1666),
                            DateCreated = new DateTime(2024, 7, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1663),
                            Email = "jane.smith@example.com",
                            Gender = 2,
                            IncomeAccount = "IA002",
                            LGA = "LGA2",
                            Name = "Jane Smith",
                            State = "State2",
                            Status = 0,
                            Type = 0
                        });
                });

            modelBuilder.Entity("TerminalMonitoringSolution.Entities.SerialNumberTracker", b =>
                {
                    b.Property<string>("EntityType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastUsedId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityType");

                    b.ToTable("SerialNumberTrackers");
                });

            modelBuilder.Entity("TerminalMonitoringSolution.Entities.Transaction", b =>
                {
                    b.Property<string>("TransactionReference")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TerminalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeLogged")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("TransactionReference");

                    b.HasIndex("TerminalId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionReference = "TRX001",
                            Amount = 100.00m,
                            Id = "TR001",
                            TerminalId = "T001",
                            TimeLogged = new DateTime(2024, 9, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1863),
                            TransactionDetails = "Initial deposit",
                            TransactionTime = new DateTime(2024, 9, 11, 17, 31, 8, 826, DateTimeKind.Local).AddTicks(1865),
                            TransactionType = 2
                        },
                        new
                        {
                            TransactionReference = "TRX002",
                            Amount = 200.00m,
                            Id = "TR002",
                            TerminalId = "T002",
                            TimeLogged = new DateTime(2024, 9, 11, 16, 31, 8, 826, DateTimeKind.Local).AddTicks(1875),
                            TransactionDetails = "Withdrawal request",
                            TransactionTime = new DateTime(2024, 9, 11, 15, 31, 8, 826, DateTimeKind.Local).AddTicks(1877),
                            TransactionType = 0
                        });
                });

            modelBuilder.Entity("TerminalMonitoringSolution.Entity.Terminal", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustodianId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("datetime2");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustodianId");

                    b.ToTable("Terminals");

                    b.HasData(
                        new
                        {
                            Id = "T001",
                            CustodianId = "C001",
                            DateAssigned = new DateTime(2024, 9, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1834),
                            Region = "Region1"
                        },
                        new
                        {
                            Id = "T002",
                            CustodianId = "C002",
                            DateAssigned = new DateTime(2024, 9, 10, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1839),
                            Region = "Region2"
                        });
                });

            modelBuilder.Entity("TerminalMonitoringSolution.Models.TerminalInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BatteryLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationApprox")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationExact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Signal")
                        .HasColumnType("int");

                    b.Property<string>("TerminalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TerminalId");

                    b.ToTable("TerminalInformation");

                    b.HasData(
                        new
                        {
                            Id = "TI001",
                            BatteryLevel = "85%",
                            IpAddress = "192.168.1.1",
                            LocationApprox = "Downtown",
                            LocationExact = "[40.7128, -74.0060]",
                            Signal = 1,
                            TerminalId = "T001",
                            TimeCreated = new DateTime(2024, 9, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1944)
                        },
                        new
                        {
                            Id = "TI002",
                            BatteryLevel = "75%",
                            IpAddress = "192.168.1.2",
                            LocationApprox = "Suburb",
                            LocationExact = "[34.0522, -118.2437]",
                            Signal = 2,
                            TerminalId = "T002",
                            TimeCreated = new DateTime(2024, 9, 11, 17, 31, 8, 826, DateTimeKind.Local).AddTicks(1949)
                        });
                });

            modelBuilder.Entity("TerminalMonitoringSolution.Entities.Transaction", b =>
                {
                    b.HasOne("TerminalMonitoringSolution.Entity.Terminal", "Terminal")
                        .WithMany("Transactions")
                        .HasForeignKey("TerminalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Terminal");
                });

            modelBuilder.Entity("TerminalMonitoringSolution.Entity.Terminal", b =>
                {
                    b.HasOne("TerminalMonitoringSolution.Entities.Custodian", "Custodian")
                        .WithMany("Terminals")
                        .HasForeignKey("CustodianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Custodian");
                });

            modelBuilder.Entity("TerminalMonitoringSolution.Models.TerminalInfo", b =>
                {
                    b.HasOne("TerminalMonitoringSolution.Entity.Terminal", "Terminal")
                        .WithMany("TerminalInfo")
                        .HasForeignKey("TerminalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Terminal");
                });

            modelBuilder.Entity("TerminalMonitoringSolution.Entities.Custodian", b =>
                {
                    b.Navigation("Terminals");
                });

            modelBuilder.Entity("TerminalMonitoringSolution.Entity.Terminal", b =>
                {
                    b.Navigation("TerminalInfo");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
