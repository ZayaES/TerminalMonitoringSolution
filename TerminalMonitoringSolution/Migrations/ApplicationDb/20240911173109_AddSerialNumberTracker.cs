using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerminalMonitoringSolution.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddSerialNumberTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "TerminalInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SerialNumberTrackers",
                columns: table => new
                {
                    EntityType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastUsedId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumberTrackers", x => x.EntityType);
                });

            migrationBuilder.UpdateData(
                table: "Custodians",
                keyColumn: "Id",
                keyValue: "C001",
                columns: new[] { "DateActivated", "DateCreated" },
                values: new object[] { new DateTime(2024, 9, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1654), new DateTime(2024, 8, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1588) });

            migrationBuilder.UpdateData(
                table: "Custodians",
                keyColumn: "Id",
                keyValue: "C002",
                columns: new[] { "DateActivated", "DateCreated" },
                values: new object[] { new DateTime(2024, 8, 27, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1666), new DateTime(2024, 7, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1663) });

            migrationBuilder.UpdateData(
                table: "TerminalInformation",
                keyColumn: "Id",
                keyValue: "TI001",
                column: "TimeCreated",
                value: new DateTime(2024, 9, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "TerminalInformation",
                keyColumn: "Id",
                keyValue: "TI002",
                column: "TimeCreated",
                value: new DateTime(2024, 9, 11, 17, 31, 8, 826, DateTimeKind.Local).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Terminals",
                keyColumn: "Id",
                keyValue: "T001",
                column: "DateAssigned",
                value: new DateTime(2024, 9, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Terminals",
                keyColumn: "Id",
                keyValue: "T002",
                column: "DateAssigned",
                value: new DateTime(2024, 9, 10, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionReference",
                keyValue: "TRX001",
                columns: new[] { "TimeLogged", "TransactionTime" },
                values: new object[] { new DateTime(2024, 9, 11, 18, 31, 8, 826, DateTimeKind.Local).AddTicks(1863), new DateTime(2024, 9, 11, 17, 31, 8, 826, DateTimeKind.Local).AddTicks(1865) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionReference",
                keyValue: "TRX002",
                columns: new[] { "TimeLogged", "TransactionTime" },
                values: new object[] { new DateTime(2024, 9, 11, 16, 31, 8, 826, DateTimeKind.Local).AddTicks(1875), new DateTime(2024, 9, 11, 15, 31, 8, 826, DateTimeKind.Local).AddTicks(1877) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerialNumberTrackers");

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "TerminalInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Custodians",
                keyColumn: "Id",
                keyValue: "C001",
                columns: new[] { "DateActivated", "DateCreated" },
                values: new object[] { new DateTime(2024, 9, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2645), new DateTime(2024, 8, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2598) });

            migrationBuilder.UpdateData(
                table: "Custodians",
                keyColumn: "Id",
                keyValue: "C002",
                columns: new[] { "DateActivated", "DateCreated" },
                values: new object[] { new DateTime(2024, 8, 26, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2652), new DateTime(2024, 7, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2650) });

            migrationBuilder.UpdateData(
                table: "TerminalInformation",
                keyColumn: "Id",
                keyValue: "TI001",
                column: "TimeCreated",
                value: new DateTime(2024, 9, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "TerminalInformation",
                keyColumn: "Id",
                keyValue: "TI002",
                column: "TimeCreated",
                value: new DateTime(2024, 9, 10, 22, 7, 41, 141, DateTimeKind.Local).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "Terminals",
                keyColumn: "Id",
                keyValue: "T001",
                column: "DateAssigned",
                value: new DateTime(2024, 9, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Terminals",
                keyColumn: "Id",
                keyValue: "T002",
                column: "DateAssigned",
                value: new DateTime(2024, 9, 9, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionReference",
                keyValue: "TRX001",
                columns: new[] { "TimeLogged", "TransactionTime" },
                values: new object[] { new DateTime(2024, 9, 10, 23, 7, 41, 141, DateTimeKind.Local).AddTicks(2775), new DateTime(2024, 9, 10, 22, 7, 41, 141, DateTimeKind.Local).AddTicks(2776) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionReference",
                keyValue: "TRX002",
                columns: new[] { "TimeLogged", "TransactionTime" },
                values: new object[] { new DateTime(2024, 9, 10, 21, 7, 41, 141, DateTimeKind.Local).AddTicks(2782), new DateTime(2024, 9, 10, 20, 7, 41, 141, DateTimeKind.Local).AddTicks(2784) });
        }
    }
}
