using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZixunWang.HotelManagement.Infrastructure.Migrations
{
    public partial class CreatingCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROOMNO = table.Column<int>(type: "int", nullable: true),
                    CNAME = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    ADDRESS = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    PHONE = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    CHECKIN = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalPERSONS = table.Column<int>(type: "int", nullable: true),
                    BookingDays = table.Column<int>(type: "int", nullable: true),
                    ADVANCE = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Rooms_ROOMNO",
                        column: x => x.ROOMNO,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ROOMNO",
                table: "Customers",
                column: "ROOMNO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
