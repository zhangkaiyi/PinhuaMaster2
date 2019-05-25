using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class RN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "行号",
                table: "tb_需求表D");

            migrationBuilder.DropColumn(
                name: "行号",
                table: "tb_订单表D");

            migrationBuilder.DropColumn(
                name: "行号",
                table: "tb_报价表D");

            migrationBuilder.AddColumn<int>(
                name: "RN",
                table: "tb_字典表D",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RN",
                table: "tb_需求表D",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RN",
                table: "tb_往来表_联系人",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RN",
                table: "tb_往来表_开票",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RN",
                table: "tb_往来表_地址",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RN",
                table: "tb_收付表D",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RN",
                table: "tb_订单表D",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RN",
                table: "tb_报价表D",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RN",
                table: "tb_IOD",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RN",
                table: "tb_字典表D");

            migrationBuilder.DropColumn(
                name: "RN",
                table: "tb_需求表D");

            migrationBuilder.DropColumn(
                name: "RN",
                table: "tb_往来表_联系人");

            migrationBuilder.DropColumn(
                name: "RN",
                table: "tb_往来表_开票");

            migrationBuilder.DropColumn(
                name: "RN",
                table: "tb_往来表_地址");

            migrationBuilder.DropColumn(
                name: "RN",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "RN",
                table: "tb_订单表D");

            migrationBuilder.DropColumn(
                name: "RN",
                table: "tb_报价表D");

            migrationBuilder.DropColumn(
                name: "RN",
                table: "tb_IOD");

            migrationBuilder.AddColumn<string>(
                name: "行号",
                table: "tb_需求表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "行号",
                table: "tb_订单表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "行号",
                table: "tb_报价表D",
                nullable: true);
        }
    }
}
