using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerminalMonitoringSolution.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class terminalInfoAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Signal",
                table: "Terminals");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Terminals");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Terminals",
                newName: "DateAssigned");

            migrationBuilder.CreateTable(
                name: "TerminalInformation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Signal = table.Column<int>(type: "int", nullable: false),
                    LocationExact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationApprox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BatteryLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerminalInformation_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TerminalInformation_TerminalId",
                table: "TerminalInformation",
                column: "TerminalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerminalInformation");

            migrationBuilder.RenameColumn(
                name: "DateAssigned",
                table: "Terminals",
                newName: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "Signal",
                table: "Terminals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Terminals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
