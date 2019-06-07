using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class Product7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "别名",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "品名",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "型号",
                table: "tb_收付表D");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "别名",
                table: "tb_收付表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "品名",
                table: "tb_收付表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "型号",
                table: "tb_收付表D",
                nullable: true);
        }
    }
}
