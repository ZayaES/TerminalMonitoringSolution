using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TerminalMonitoringSolution.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class SeedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Custodians",
                columns: new[] { "Id", "ANM", "Address", "Cluster", "ClusterCode", "ClusterManager", "ContactNumber", "DateActivated", "DateCreated", "Email", "Gender", "IncomeAccount", "LGA", "Name", "State", "Status", "Type" },
                values: new object[,]
                {
                    { "C001", "ANM1", "123 Main St", "Cluster1", "CC001", "Manager1", "123-456-7890", new DateTime(2024, 9, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2645), new DateTime(2024, 8, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2598), "john.doe@example.com", 1, "IA001", "LGA1", "John Doe", "State1", 1, 1 },
                    { "C002", "ANM2", "456 Elm St", "Cluster2", "CC002", "Manager2", "098-765-4321", new DateTime(2024, 8, 26, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2652), new DateTime(2024, 7, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2650), "jane.smith@example.com", 2, "IA002", "LGA2", "Jane Smith", "State2", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Terminals",
                columns: new[] { "Id", "CustodianId", "DateAssigned", "Region" },
                values: new object[,]
                {
                    { "T001", "C001", new DateTime(2024, 9, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2756), "Region1" },
                    { "T002", "C002", new DateTime(2024, 9, 9, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2759), "Region2" }
                });

            migrationBuilder.InsertData(
                table: "TerminalInformation",
                columns: new[] { "Id", "BatteryLevel", "IpAddress", "LocationApprox", "LocationExact", "Signal", "TerminalId", "TimeCreated" },
                values: new object[,]
                {
                    { "TI001", "85%", "192.168.1.1", "Downtown", "[40.7128, -74.0060]", 1, "T001", new DateTime(2024, 9, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2799) },
                    { "TI002", "75%", "192.168.1.2", "Suburb", "[34.0522, -118.2437]", 2, "T002", new DateTime(2024, 9, 10, 22, 7, 41, 141, DateTimeKind.Local).AddTicks(2805) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionReference", "Amount", "Id", "TerminalId", "TimeLogged", "TransactionDetails", "TransactionTime", "TransactionType" },
                values: new object[,]
                {
                    { "TRX001", 100.00m, "TR001", "T001", new DateTime(2024, 9, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2775), "Initial deposit", new DateTime(2024, 9, 10, 22, 7, 41, 141, DateTimeKind.Local).AddTicks(2776), 2 },
                    { "TRX002", 200.00m, "TR002", "T002", new DateTime(2024, 9, 10, 21, 7, 41, 141, DateTimeKind.Local).AddTicks(2782), "Withdrawal request", new DateTime(2024, 9, 10, 20, 7, 41, 141, DateTimeKind.Local).AddTicks(2784), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TerminalInformation",
                keyColumn: "Id",
                keyValue: "TI001");

            migrationBuilder.DeleteData(
                table: "TerminalInformation",
                keyColumn: "Id",
                keyValue: "TI002");

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionReference",
                keyValue: "TRX001");

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionReference",
                keyValue: "TRX002");

            migrationBuilder.DeleteData(
                table: "Terminals",
                keyColumn: "Id",
                keyValue: "T001");

            migrationBuilder.DeleteData(
                table: "Terminals",
                keyColumn: "Id",
                keyValue: "T002");

            migrationBuilder.DeleteData(
                table: "Custodians",
                keyColumn: "Id",
                keyValue: "C001");

            migrationBuilder.DeleteData(
                table: "Custodians",
                keyColumn: "Id",
                keyValue: "C002");
        }
    }
}
