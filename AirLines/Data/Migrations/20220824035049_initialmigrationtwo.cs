using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirLines.Data.Migrations
{
    public partial class initialmigrationtwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PanNumber",
                table: "user",
                type: "bigint",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PanNumber",
                table: "user",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 10);
        }
    }
}
