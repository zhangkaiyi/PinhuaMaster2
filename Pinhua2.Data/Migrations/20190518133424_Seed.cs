using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "sysAutoCode",
                keyColumn: "AutoCodeId",
                keyValue: 100,
                column: "DateType",
                value: "yyMM");

            migrationBuilder.InsertData(
                table: "sysAutoCode",
                columns: new[] { "AutoCodeId", "AllowBatch", "AllowMore", "AutoCodeName", "CreateTime", "CreateUser", "DateType", "IsActive", "Memo", "Prefix", "ReuseType", "RunBeforeSave", "SeedLength", "SeedStart", "SysVar" },
                values: new object[,]
                {
                    { 101, null, null, "子单号", null, 2, "yy", 1, null, null, null, 1, 6, 1, null },
                    { 200, null, null, "商品号", null, 2, null, 1, null, "10", null, 1, 8, 1, null },
                    { 300, null, null, "往来号", null, 2, "yy", 1, null, null, null, 1, 4, 1, null },
                    { 400, null, null, "档案号", null, 2, "yy", 1, null, null, null, 1, 4, 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "sysAutoCode",
                keyColumn: "AutoCodeId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "sysAutoCode",
                keyColumn: "AutoCodeId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "sysAutoCode",
                keyColumn: "AutoCodeId",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "sysAutoCode",
                keyColumn: "AutoCodeId",
                keyValue: 400);

            migrationBuilder.UpdateData(
                table: "sysAutoCode",
                keyColumn: "AutoCodeId",
                keyValue: 100,
                column: "DateType",
                value: "yyMMdd");
        }
    }
}
