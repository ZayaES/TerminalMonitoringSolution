using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerminalMonitoringSolution.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class CreationOfApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Custodians",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cluster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClusterCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClusterManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ANM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateActivated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IncomeAccount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custodians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustodianId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Signal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terminals_Custodians_CustodianId",
                        column: x => x.CustodianId,
                        principalTable: "Custodians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionReference = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLogged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TerminalId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionReference);
                    table.ForeignKey(
                        name: "FK_Transactions_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_CustodianId",
                table: "Terminals",
                column: "CustodianId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TerminalId",
                table: "Transactions",
                column: "TerminalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Terminals");

            migrationBuilder.DropTable(
                name: "Custodians");
        }
    }
}
