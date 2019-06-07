using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class Product6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "描述",
                table: "tb_收付表D",
                newName: "型号");

            migrationBuilder.AddColumn<decimal>(
                name: "个数",
                table: "tb_收付表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "别名",
                table: "tb_收付表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "品号",
                table: "tb_收付表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "品名",
                table: "tb_收付表D",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "个数",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "别名",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "品号",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "品名",
                table: "tb_收付表D");

            migrationBuilder.RenameColumn(
                name: "型号",
                table: "tb_收付表D",
                newName: "描述");
        }
    }
}
