using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class BaseProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "宽度",
                table: "tb_需求表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "长度",
                table: "tb_需求表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "面厚",
                table: "tb_需求表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "高度",
                table: "tb_需求表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "宽度",
                table: "tb_收付表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "长度",
                table: "tb_收付表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "面厚",
                table: "tb_收付表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "高度",
                table: "tb_收付表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "宽度",
                table: "tb_订单表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "长度",
                table: "tb_订单表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "面厚",
                table: "tb_订单表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "高度",
                table: "tb_订单表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "宽度",
                table: "tb_报价表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "长度",
                table: "tb_报价表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "面厚",
                table: "tb_报价表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "高度",
                table: "tb_报价表D",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "宽度",
                table: "tb_IOD",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "长度",
                table: "tb_IOD",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "面厚",
                table: "tb_IOD",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "高度",
                table: "tb_IOD",
                type: "decimal(18,6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "宽度",
                table: "tb_需求表D");

            migrationBuilder.DropColumn(
                name: "长度",
                table: "tb_需求表D");

            migrationBuilder.DropColumn(
                name: "面厚",
                table: "tb_需求表D");

            migrationBuilder.DropColumn(
                name: "高度",
                table: "tb_需求表D");

            migrationBuilder.DropColumn(
                name: "宽度",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "长度",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "面厚",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "高度",
                table: "tb_收付表D");

            migrationBuilder.DropColumn(
                name: "宽度",
                table: "tb_订单表D");

            migrationBuilder.DropColumn(
                name: "长度",
                table: "tb_订单表D");

            migrationBuilder.DropColumn(
                name: "面厚",
                table: "tb_订单表D");

            migrationBuilder.DropColumn(
                name: "高度",
                table: "tb_订单表D");

            migrationBuilder.DropColumn(
                name: "宽度",
                table: "tb_报价表D");

            migrationBuilder.DropColumn(
                name: "长度",
                table: "tb_报价表D");

            migrationBuilder.DropColumn(
                name: "面厚",
                table: "tb_报价表D");

            migrationBuilder.DropColumn(
                name: "高度",
                table: "tb_报价表D");

            migrationBuilder.DropColumn(
                name: "宽度",
                table: "tb_IOD");

            migrationBuilder.DropColumn(
                name: "长度",
                table: "tb_IOD");

            migrationBuilder.DropColumn(
                name: "面厚",
                table: "tb_IOD");

            migrationBuilder.DropColumn(
                name: "高度",
                table: "tb_IOD");
        }
    }
}
