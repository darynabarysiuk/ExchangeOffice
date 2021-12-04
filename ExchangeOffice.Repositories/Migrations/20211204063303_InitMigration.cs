using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeOffice.Repositories.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Сurrencies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сurrencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cashers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "СurrencyLimits",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Limit = table.Column<double>(type: "float", nullable: false),
                    CurrencyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_СurrencyLimits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_СurrencyLimits_Сurrencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Сurrencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CurrencyIDFrom = table.Column<int>(type: "int", nullable: false),
                    CurrencyIDTo = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CurrencyRates_Сurrencies_CurrencyIDFrom",
                        column: x => x.CurrencyIDFrom,
                        principalTable: "Сurrencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencyRates_Сurrencies_CurrencyIDTo",
                        column: x => x.CurrencyIDTo,
                        principalTable: "Сurrencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyRateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OperationHistories_CurrencyRates_CurrencyRateID",
                        column: x => x.CurrencyRateID,
                        principalTable: "CurrencyRates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_СurrencyLimits_CurrencyID",
                table: "СurrencyLimits",
                column: "CurrencyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_CurrencyIDFrom",
                table: "CurrencyRates",
                column: "CurrencyIDFrom");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_CurrencyIDTo",
                table: "CurrencyRates",
                column: "CurrencyIDTo");

            migrationBuilder.CreateIndex(
                name: "IX_OperationHistories_CurrencyRateID",
                table: "OperationHistories",
                column: "CurrencyRateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "СurrencyLimits");

            migrationBuilder.DropTable(
                name: "Cashers");

            migrationBuilder.DropTable(
                name: "OperationHistories");

            migrationBuilder.DropTable(
                name: "CurrencyRates");

            migrationBuilder.DropTable(
                name: "Сurrencies");
        }
    }
}
