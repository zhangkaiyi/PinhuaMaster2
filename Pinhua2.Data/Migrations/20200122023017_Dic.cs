using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class Dic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "字典名",
                table: "tb_字典表D");

            migrationBuilder.DropColumn(
                name: "序",
                table: "tb_字典表D");

            migrationBuilder.DropColumn(
                name: "描述",
                table: "tb_字典表D");

            migrationBuilder.DropColumn(
                name: "组",
                table: "tb_字典表D");

            migrationBuilder.DropColumn(
                name: "组",
                table: "tb_字典表");

            migrationBuilder.AddColumn<string>(
                name: "字典号",
                table: "tb_字典表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "组号",
                table: "tb_字典表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "编号",
                table: "tb_字典表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "字典号",
                table: "tb_字典表",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "组号",
                table: "tb_字典表",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "组名",
                table: "tb_字典表",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "字典号",
                table: "tb_字典表D");

            migrationBuilder.DropColumn(
                name: "组号",
                table: "tb_字典表D");

            migrationBuilder.DropColumn(
                name: "编号",
                table: "tb_字典表D");

            migrationBuilder.DropColumn(
                name: "字典号",
                table: "tb_字典表");

            migrationBuilder.DropColumn(
                name: "组号",
                table: "tb_字典表");

            migrationBuilder.DropColumn(
                name: "组名",
                table: "tb_字典表");

            migrationBuilder.AddColumn<string>(
                name: "字典名",
                table: "tb_字典表D",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "序",
                table: "tb_字典表D",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "描述",
                table: "tb_字典表D",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "组",
                table: "tb_字典表D",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "组",
                table: "tb_字典表",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
