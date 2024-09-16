using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerminalMonitoringSolution.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class TransactionTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateLogged",
                table: "Transactions",
                newName: "TimeLogged");

            migrationBuilder.AddColumn<string>(
                name: "TransactionDetails",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionDetails",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TimeLogged",
                table: "Transactions",
                newName: "DateLogged");
        }
    }
}
