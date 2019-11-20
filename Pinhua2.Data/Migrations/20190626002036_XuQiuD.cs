using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class XuQiuD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "个数",
                table: "tb_需求表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "别名",
                table: "tb_需求表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "型号",
                table: "tb_需求表D",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "个数",
                table: "tb_需求表D");

            migrationBuilder.DropColumn(
                name: "别名",
                table: "tb_需求表D");

            migrationBuilder.DropColumn(
                name: "型号",
                table: "tb_需求表D");
        }
    }
}
