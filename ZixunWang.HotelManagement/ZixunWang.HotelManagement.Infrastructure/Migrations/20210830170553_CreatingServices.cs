using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZixunWang.HotelManagement.Infrastructure.Migrations
{
    public partial class CreatingServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROOMNO = table.Column<int>(type: "int", nullable: true),
                    SDESC = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    AMOUNT = table.Column<decimal>(type: "money", nullable: true),
                    ServiceDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Rooms_ROOMNO",
                        column: x => x.ROOMNO,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_ROOMNO",
                table: "Services",
                column: "ROOMNO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
