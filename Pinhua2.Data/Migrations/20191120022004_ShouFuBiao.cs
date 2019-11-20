using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class ShouFuBiao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "关联单号",
                table: "tb_收付表",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "小类",
                table: "tb_收付表",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "关联单号",
                table: "tb_收付表");

            migrationBuilder.DropColumn(
                name: "小类",
                table: "tb_收付表");
        }
    }
}
