using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class IsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_字典表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_证照表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_员工表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_需求表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_往来表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_收付表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_设备表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_商品表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_工序表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_订单表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_报价表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_班组表",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_IO",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_字典表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_证照表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_员工表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_需求表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_往来表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_收付表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_设备表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_商品表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_工序表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_订单表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_报价表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_班组表");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_IO");
        }
    }
}
