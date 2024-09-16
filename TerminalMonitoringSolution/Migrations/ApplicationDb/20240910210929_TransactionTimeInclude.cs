using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerminalMonitoringSolution.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class TransactionTimeInclude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionTime",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionTime",
                table: "Transactions");
        }
    }
}
