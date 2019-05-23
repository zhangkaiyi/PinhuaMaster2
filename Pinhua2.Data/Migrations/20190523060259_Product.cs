using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "型号",
                table: "tb_商品表",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "型号",
                table: "tb_商品表");
        }
    }
}
