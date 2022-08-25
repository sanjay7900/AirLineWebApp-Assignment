using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirLineDbLayer.Data.Migrations
{
    public partial class InitailMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FromCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ToCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Fare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLine", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirLine_Name",
                table: "AirLine",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirLine");
        }
    }
}
