using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalculatorAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculationDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstInput = table.Column<int>(nullable: false),
                    SecontInput = table.Column<int>(nullable: false),
                    Result = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationDetails");
        }
    }
}
