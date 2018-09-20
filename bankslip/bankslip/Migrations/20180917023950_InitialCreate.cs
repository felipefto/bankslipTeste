using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bankslip.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bankslip",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    due_date = table.Column<DateTime>(nullable: false),
                    payment_date = table.Column<DateTime>(nullable: false),
                    total_in_cents = table.Column<decimal>(nullable: false),
                    customer = table.Column<string>(nullable: true),
                    fine = table.Column<decimal>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankslip", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bankslip");
        }
    }
}
