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
                property.SetColumnType("decimal(18,6)");
            }

            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(t => t.GetProperties())
            //    .Where(p => p.ClrType == typeof(Guid) || p.ClrType == typeof(Guid?)))
            //{
            //    property.Relational().DefaultValueSql = "NEWID()";
            //}

            //modelBuilder.Entity<sysAutoCode>()
            //                .Property(p => p.DateType)
            //                .HasColumnType("TINYINT")
            //                .HasConversion<byte>();

            modelBuilder.Entity<sys_AutoCode>().HasData(
                new sys_AutoCode
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
                new sys_AutoCode
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
                new sys_AutoCode
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
                new sys_AutoCode
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
                new sys_AutoCode
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
        public DbSet<sys_AutoCode> sys_AutoCode { get; set; }
        public DbSet<sys_AutoCodeRegister> sys_AutoCodeRegister { get; set; }
        public DbSet<tb_班组表> tb_班组表 { get; set; }
        public DbSet<tb_报价表> tb_报价表 { get; set; }
        public DbSet<tb_报价表D> tb_报价表D { get; set; }
        public DbSet<tb_订单表> tb_订单表 { get; set; }
        public DbSet<tb_订单表D> tb_订单表D { get; set; }
        public DbSet<tb_工序表> tb_工序表 { get; set; }
        public DbSet<tb_商品表> tb_商品表 { get; set; }
        public DbSet<tb_设备表> tb_设备表 { get; set; }
        public DbSet<tb_IO> tb_IO { get; set; }
        public DbSet<tb_IOD> tb_IOD { get; set; }
        public DbSet<tb_收付表> tb_收付表 { get; set; }
        public DbSet<tb_收付表D> tb_收付表D { get; set; }
        public DbSet<tb_往来表> tb_往来表 { get; set; }
        public DbSet<tb_需求表> tb_需求表 { get; set; }
        public DbSet<tb_需求表D> tb_需求表D { get; set; }
        public DbSet<tb_员工表> tb_员工表 { get; set; }
        public DbSet<tb_证照表> tb_证照表 { get; set; }
        public DbSet<tb_字典表> tb_字典表 { get; set; }
        public DbSet<tb_字典表D> tb_字典表D { get; set; }
        public DbSet<tb_往来表_地址> tb_往来表_地址 { get; set; }
        public DbSet<tb_往来表_开票> tb_往来表_开票 { get; set; }
        public DbSet<tb_往来表_联系人> tb_往来表_联系人 { get; set; }
    }
}
