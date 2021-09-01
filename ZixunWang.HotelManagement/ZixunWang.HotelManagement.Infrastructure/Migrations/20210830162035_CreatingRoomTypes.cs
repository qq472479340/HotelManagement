using Microsoft.EntityFrameworkCore.Migrations;

namespace ZixunWang.HotelManagement.Infrastructure.Migrations
{
    public partial class CreatingRoomTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RTDESC = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Rent = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
