using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pinhua2.Data.Models;
using System;
using System.Linq;

namespace Pinhua2.Data
{
    public class Pinhua2Context : DbContext
    {
        public Pinhua2Context(DbContextOptions<Pinhua2Context> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //当model创建的时候 ，你可以添加一些特性
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Product>().HasIndex(u => u.ProductName).IsUnique();
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.Relational().ColumnType = "decimal(18,6)";
            }

            //modelBuilder.Entity<sysAutoCode>()
            //                .Property(p => p.DateType)
            //                .HasColumnType("TINYINT")
            //                .HasConversion<byte>();

            modelBuilder.Entity<sysAutoCode>().HasData(
                new sysAutoCode
                {
                    AutoCodeId = 100,
                    AutoCodeName = "订单号",
                    DateType = AutoCodeDateType.yyMM.ToString(),
                    SeedStart = 1,
                    SeedLength = 4,
                    RunBeforeSave = 1,
                    CreateUser = 2,
                    IsActive = 1
                },
                new sysAutoCode
                {
                    AutoCodeId = 101,
                    AutoCodeName = "子单号",
                    DateType = AutoCodeDateType.yy.ToString(),
                    SeedStart = 1,
                    SeedLength = 6,
                    RunBeforeSave = 1,
                    CreateUser = 2,
                    IsActive = 1
                },
                new sysAutoCode
                {
                    AutoCodeId = 200,
                    AutoCodeName = "商品号",
                    Prefix = "10",
                    SeedStart = 1,
                    SeedLength = 8,
                    RunBeforeSave = 1,
                    CreateUser = 2,
                    IsActive = 1
                },
                new sysAutoCode
                {
                    AutoCodeId = 300,
                    AutoCodeName = "往来号",
                    DateType = AutoCodeDateType.yy.ToString(),
                    SeedStart = 1,
                    SeedLength = 4,
                    RunBeforeSave = 1,
                    CreateUser = 2,
                    IsActive = 1
                },
                new sysAutoCode
                {
                    AutoCodeId = 400,
                    AutoCodeName = "档案号",
                    DateType = AutoCodeDateType.yy.ToString(),
                    SeedStart = 1,
                    SeedLength = 4,
                    RunBeforeSave = 1,
                    CreateUser = 2,
                    IsActive = 1
                });
        }
        public DbSet<sysAutoCode> sysAutoCode { get; set; }
        public DbSet<sysAutoCodeRegister> sysAutoCodeRegister { get; set; }
        public DbSet<sys班组表> sys班组表 { get; set; }
        public DbSet<sys报价表> sys报价表 { get; set; }
        public DbSet<sys报价表_D> sys报价表_D { get; set; }
        public DbSet<sys订单表> sys订单表 { get; set; }
        public DbSet<sys订单表_D> sys订单表_D { get; set; }
        public DbSet<sys付款条件表> sys付款条件表 { get; set; }
        public DbSet<sys工序表> sys工序表 { get; set; }
        public DbSet<sys商品表> sys商品表 { get; set; }
        public DbSet<sys设备表> sys设备表 { get; set; }
        public DbSet<sysIO> sysIO { get; set; }
        public DbSet<sysIO_D> sysIO_D { get; set; }
        public DbSet<sys收付表> sys收付表 { get; set; }
        public DbSet<sys收付表_D> sys收付表_D { get; set; }
        public DbSet<sys往来表> sys往来表 { get; set; }
        public DbSet<sys需求表> sys需求表 { get; set; }
        public DbSet<sys需求表_D> sys需求表_D { get; set; }
        public DbSet<sys员工表> sys员工表 { get; set; }
        public DbSet<sys证照表> sys证照表 { get; set; }
        public DbSet<sys字典表> sys字典表 { get; set; }
        public DbSet<sys字典表_D> sys字典表_D { get; set; }
        public DbSet<sys地址表> sys往来表_地址 { get; set; }
        public DbSet<sys开票表> sys往来表_开票 { get; set; }
        public DbSet<sys联系人表> sys往来表_联系人 { get; set; }
    }
}
