using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class LockStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_字典表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_证照表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_员工表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_需求表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_往来表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_收付表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_设备表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_商品表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_工序表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_订单表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_报价表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_班组表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_IO",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_字典表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_证照表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_员工表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_需求表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_往来表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_收付表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_设备表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_商品表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_工序表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_订单表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_报价表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_班组表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_IO");
        }
    }
}
