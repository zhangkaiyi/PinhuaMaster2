using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class Product3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "别名",
                table: "tb_订单表D",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "型号",
                table: "tb_订单表D",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "别名",
                table: "tb_订单表D");

            migrationBuilder.DropColumn(
                name: "型号",
                table: "tb_订单表D");
        }
    }
}
