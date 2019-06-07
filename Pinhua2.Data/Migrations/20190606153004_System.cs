using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class System : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_字典表D");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "tb_字典表D");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_字典表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_字典表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_字典表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_证照表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_证照表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_证照表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_员工表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_员工表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_员工表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_需求表D");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "tb_需求表D");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_需求表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_需求表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_需求表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_往来表_联系人");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "tb_往来表_联系人");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_往来表_开票");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "tb_往来表_开票");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_往来表_地址");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "tb_往来表_地址");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_往来表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_往来表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_往来表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_收付表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_收付表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_收付表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_设备表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_设备表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_设备表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_商品表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_商品表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_商品表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_工序表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_工序表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_工序表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_订单表D");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "tb_订单表D");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_订单表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_订单表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_订单表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_报价表D");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "tb_报价表D");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_报价表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_报价表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_报价表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_班组表");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_班组表");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_班组表");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_IOD");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "tb_IOD");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "tb_IO");

            migrationBuilder.DropColumn(
                name: "LockStatus",
                table: "tb_IO");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "tb_IO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_字典表D",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "tb_字典表D",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_字典表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_字典表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_字典表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_证照表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_证照表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_证照表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_员工表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_员工表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_员工表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_需求表D",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "tb_需求表D",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_需求表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_需求表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_需求表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_往来表_联系人",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "tb_往来表_联系人",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_往来表_开票",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "tb_往来表_开票",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_往来表_地址",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "tb_往来表_地址",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_往来表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_往来表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_往来表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_收付表D",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "tb_收付表D",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_收付表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_收付表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_收付表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_设备表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_设备表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_设备表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_商品表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_商品表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_商品表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_工序表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_工序表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_工序表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_订单表D",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "tb_订单表D",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_订单表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_订单表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_订单表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_报价表D",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "tb_报价表D",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_报价表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_报价表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_报价表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_班组表",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_班组表",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_班组表",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_IOD",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "tb_IOD",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "tb_IO",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LockStatus",
                table: "tb_IO",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "tb_IO",
                nullable: true);
        }
    }
}
