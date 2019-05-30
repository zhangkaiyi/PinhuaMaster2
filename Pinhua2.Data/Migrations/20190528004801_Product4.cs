using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class Product4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "子单号",
                table: "tb_字典表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "子单号",
                table: "tb_往来表_联系人",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "子单号",
                table: "tb_往来表_开票",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "子单号",
                table: "tb_往来表_地址",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "子单号",
                table: "tb_字典表D");

            migrationBuilder.DropColumn(
                name: "子单号",
                table: "tb_往来表_联系人");

            migrationBuilder.DropColumn(
                name: "子单号",
                table: "tb_往来表_开票");

            migrationBuilder.DropColumn(
                name: "子单号",
                table: "tb_往来表_地址");
        }
    }
}
