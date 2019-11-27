﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pinhua2.Data;

namespace Pinhua2.Data.Migrations
{
    [DbContext(typeof(Pinhua2Context))]
    [Migration("20191127150103_BaseProductDetail")]
    partial class BaseProductDetail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pinhua2.Data.Models.sys_AutoCode", b =>
                {
                    b.Property<int>("AutoCodeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AllowBatch");

                    b.Property<int?>("AllowMore");

                    b.Property<string>("AutoCodeName");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<int?>("CreateUser");

                    b.Property<string>("DateType");

                    b.Property<int?>("IsActive");

                    b.Property<string>("Memo");

                    b.Property<string>("Prefix");

                    b.Property<int?>("ReuseType");

                    b.Property<int?>("RunBeforeSave");

                    b.Property<int?>("SeedLength");

                    b.Property<int?>("SeedStart");

                    b.Property<int?>("SysVar");

                    b.HasKey("AutoCodeId");

                    b.ToTable("sys_AutoCode");

                    b.HasData(
                        new
                        {
                            AutoCodeId = 100,
                            AutoCodeName = "订单号",
                            CreateUser = 2,
                            DateType = "yyMM",
                            IsActive = 1,
                            RunBeforeSave = 1,
                            SeedLength = 4,
                            SeedStart = 1
                        },
                        new
                        {
                            AutoCodeId = 101,
                            AutoCodeName = "子单号",
                            CreateUser = 2,
                            DateType = "yy",
                            IsActive = 1,
                            RunBeforeSave = 1,
                            SeedLength = 6,
                            SeedStart = 1
                        },
                        new
                        {
                            AutoCodeId = 200,
                            AutoCodeName = "商品号",
                            CreateUser = 2,
                            IsActive = 1,
                            Prefix = "10",
                            RunBeforeSave = 1,
                            SeedLength = 8,
                            SeedStart = 1
                        },
                        new
                        {
                            AutoCodeId = 300,
                            AutoCodeName = "往来号",
                            CreateUser = 2,
                            DateType = "yy",
                            IsActive = 1,
                            RunBeforeSave = 1,
                            SeedLength = 4,
                            SeedStart = 1
                        },
                        new
                        {
                            AutoCodeId = 400,
                            AutoCodeName = "档案号",
                            CreateUser = 2,
                            DateType = "yy",
                            IsActive = 1,
                            RunBeforeSave = 1,
                            SeedLength = 4,
                            SeedStart = 1
                        });
                });

            modelBuilder.Entity("Pinhua2.Data.Models.sys_AutoCodeRegister", b =>
                {
                    b.Property<int>("Idx")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AutoCodeId");

                    b.Property<int?>("CurrentSeed");

                    b.Property<string>("PrimaryPart");

                    b.HasKey("Idx");

                    b.ToTable("sys_AutoCodeRegister");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_IO", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.Property<string>("仓");

                    b.Property<string>("保修类型");

                    b.Property<string>("制单");

                    b.Property<string>("单号");

                    b.Property<string>("备注");

                    b.Property<string>("往来");

                    b.Property<string>("往来号");

                    b.Property<DateTime?>("日期");

                    b.Property<string>("物流单号");

                    b.Property<string>("类型");

                    b.Property<string>("订单号");

                    b.Property<decimal?>("退单")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("RecordId");

                    b.ToTable("tb_IO");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_IOD", b =>
                {
                    b.Property<int>("Idx")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RN");

                    b.Property<int?>("RecordId");

                    b.Property<string>("仓");

                    b.Property<string>("别名");

                    b.Property<decimal?>("单价")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("单位");

                    b.Property<decimal?>("发")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("品号");

                    b.Property<string>("品名");

                    b.Property<string>("品牌");

                    b.Property<string>("型号");

                    b.Property<string>("备注");

                    b.Property<string>("子单号");

                    b.Property<decimal?>("已完数")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("库位");

                    b.Property<string>("库存");

                    b.Property<string>("批次");

                    b.Property<decimal?>("收")
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime?>("日期");

                    b.Property<string>("日期唛");

                    b.Property<string>("条码");

                    b.Property<string>("版本号");

                    b.Property<decimal?>("税率")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("行号");

                    b.Property<string>("规格");

                    b.Property<decimal?>("计划数")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("订单号");

                    b.Property<decimal?>("质保")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("金额")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Idx");

                    b.ToTable("tb_IOD");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_员工表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.Property<DateTime?>("入职日期");

                    b.Property<DateTime?>("合同到期日期");

                    b.Property<DateTime?>("合同签订日期");

                    b.Property<string>("地址");

                    b.Property<decimal?>("基本工资")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("姓名");

                    b.Property<string>("婚姻");

                    b.Property<string>("学历");

                    b.Property<string>("宅电");

                    b.Property<string>("属性");

                    b.Property<string>("工号");

                    b.Property<string>("性别");

                    b.Property<string>("手机");

                    b.Property<string>("是否签合同");

                    b.Property<string>("是否购社保");

                    b.Property<string>("状态");

                    b.Property<DateTime?>("生日");

                    b.Property<string>("电话");

                    b.Property<DateTime?>("社保开始日期");

                    b.Property<DateTime?>("社保退交日期");

                    b.Property<DateTime?>("离职日期");

                    b.Property<string>("紧急联系人");

                    b.Property<string>("紧急联系人关系");

                    b.Property<string>("紧急联系人地址");

                    b.Property<string>("紧急联系方式");

                    b.Property<string>("职位");

                    b.Property<string>("身份证号");

                    b.Property<string>("部门");

                    b.HasKey("RecordId");

                    b.ToTable("tb_员工表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_商品表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.Property<string>("上级品号");

                    b.Property<string>("上级品名");

                    b.Property<string>("供应商");

                    b.Property<string>("供应商号");

                    b.Property<string>("分类1");

                    b.Property<string>("分类2");

                    b.Property<string>("别名");

                    b.Property<string>("单位");

                    b.Property<decimal?>("单重")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("品号");

                    b.Property<string>("品名");

                    b.Property<string>("品牌");

                    b.Property<string>("图片");

                    b.Property<int?>("图片I");

                    b.Property<string>("型号");

                    b.Property<string>("备注");

                    b.Property<string>("大类");

                    b.Property<decimal?>("安全库存")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("客户");

                    b.Property<string>("客户号");

                    b.Property<string>("客户料号");

                    b.Property<decimal?>("宽度")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("库位");

                    b.Property<string>("拼音码");

                    b.Property<decimal?>("指定销售价")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("换算单位");

                    b.Property<decimal?>("换算系数")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("是否共用");

                    b.Property<string>("是否存储");

                    b.Property<string>("是否采购");

                    b.Property<string>("是否销售");

                    b.Property<decimal?>("最新采购价")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("材质");

                    b.Property<string>("条码");

                    b.Property<string>("档案号");

                    b.Property<string>("版本号");

                    b.Property<string>("状态");

                    b.Property<string>("色号");

                    b.Property<string>("表面处理");

                    b.Property<string>("规格");

                    b.Property<string>("计算公式");

                    b.Property<decimal?>("质保")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("采购价")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("采购周期")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("链接");

                    b.Property<decimal?>("销售价")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("长度")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("面厚")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("高度")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("RecordId");

                    b.ToTable("tb_商品表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_字典表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.Property<string>("字典名");

                    b.Property<string>("组");

                    b.HasKey("RecordId");

                    b.ToTable("tb_字典表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_字典表D", b =>
                {
                    b.Property<int>("Idx")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RN");

                    b.Property<int?>("RecordId");

                    b.Property<string>("代码");

                    b.Property<string>("名称");

                    b.Property<string>("子单号");

                    b.Property<string>("字典名");

                    b.Property<int?>("序");

                    b.Property<string>("描述");

                    b.Property<string>("组");

                    b.HasKey("Idx");

                    b.ToTable("tb_字典表D");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_工序表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.HasKey("RecordId");

                    b.ToTable("tb_工序表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_往来表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<string>("Email");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.Property<string>("Qq");

                    b.Property<string>("付款方式");

                    b.Property<string>("传真");

                    b.Property<decimal?>("信用额")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("全称");

                    b.Property<string>("公司电话");

                    b.Property<string>("地址");

                    b.Property<string>("币种");

                    b.Property<string>("开户行");

                    b.Property<string>("往来号");

                    b.Property<string>("状态");

                    b.Property<DateTime?>("登记日期");

                    b.Property<string>("登记部门");

                    b.Property<string>("税收组");

                    b.Property<string>("简称");

                    b.Property<string>("类型");

                    b.Property<string>("组织代码");

                    b.Property<string>("联系人");

                    b.Property<string>("联系电话");

                    b.Property<string>("负责人");

                    b.Property<string>("账号");

                    b.HasKey("RecordId");

                    b.ToTable("tb_往来表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_往来表_地址", b =>
                {
                    b.Property<int>("Idx")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RN");

                    b.Property<int?>("RecordId");

                    b.Property<string>("地址");

                    b.Property<string>("子单号");

                    b.Property<string>("往来号");

                    b.Property<string>("电话");

                    b.Property<string>("联系人");

                    b.HasKey("Idx");

                    b.ToTable("tb_往来表_地址");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_往来表_开票", b =>
                {
                    b.Property<int>("Idx")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RN");

                    b.Property<int?>("RecordId");

                    b.Property<string>("发票抬头");

                    b.Property<string>("子单号");

                    b.Property<string>("往来号");

                    b.Property<string>("税号");

                    b.Property<string>("账号");

                    b.HasKey("Idx");

                    b.ToTable("tb_往来表_开票");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_往来表_联系人", b =>
                {
                    b.Property<int>("Idx")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Qq");

                    b.Property<int?>("RN");

                    b.Property<int?>("RecordId");

                    b.Property<string>("传真");

                    b.Property<string>("备注");

                    b.Property<string>("子单号");

                    b.Property<string>("往来号");

                    b.Property<string>("手机");

                    b.Property<string>("电话");

                    b.Property<string>("职位");

                    b.Property<string>("联系人");

                    b.Property<string>("部门");

                    b.HasKey("Idx");

                    b.ToTable("tb_往来表_联系人");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_报价表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.Property<string>("业务类型");

                    b.Property<DateTime?>("交期");

                    b.Property<string>("仓");

                    b.Property<string>("制单");

                    b.Property<string>("单号");

                    b.Property<string>("备注");

                    b.Property<string>("往来");

                    b.Property<string>("往来单号");

                    b.Property<string>("往来号");

                    b.Property<DateTime?>("日期");

                    b.Property<string>("需求单");

                    b.HasKey("RecordId");

                    b.ToTable("tb_报价表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_报价表D", b =>
                {
                    b.Property<int>("Idx")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RN");

                    b.Property<int?>("RecordId");

                    b.Property<decimal?>("上次价")
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime?>("上次日期");

                    b.Property<decimal?>("个数")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("别名");

                    b.Property<decimal?>("单价")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("单位");

                    b.Property<string>("品号");

                    b.Property<string>("品名");

                    b.Property<string>("品牌");

                    b.Property<string>("型号");

                    b.Property<string>("备注");

                    b.Property<string>("子单号");

                    b.Property<decimal?>("库存")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("数量")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("状态");

                    b.Property<decimal?>("税率")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("规格");

                    b.Property<decimal?>("金额")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Idx");

                    b.ToTable("tb_报价表D");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_收付表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.Property<decimal?>("付")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("关联单号");

                    b.Property<decimal?>("分配")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("制单");

                    b.Property<string>("单号");

                    b.Property<string>("发票号");

                    b.Property<string>("备注");

                    b.Property<string>("小类");

                    b.Property<string>("往来");

                    b.Property<string>("往来号");

                    b.Property<decimal?>("收")
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime?>("日期");

                    b.Property<string>("类型");

                    b.HasKey("RecordId");

                    b.ToTable("tb_收付表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_收付表D", b =>
                {
                    b.Property<int>("Idx")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RN");

                    b.Property<int?>("RecordId");

                    b.Property<decimal?>("个数")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("别名");

                    b.Property<string>("单位");

                    b.Property<decimal?>("可收付款额")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("品号");

                    b.Property<string>("品名");

                    b.Property<string>("型号");

                    b.Property<string>("备注");

                    b.Property<string>("子单号");

                    b.Property<decimal?>("已收付款数")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("已收付款额")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("待收付款额")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("收发数")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("收发额")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("数量")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("本次付数")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("本次付额")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("本次收数")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("本次收额")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("规格");

                    b.Property<decimal?>("金额")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Idx");

                    b.ToTable("tb_收付表D");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_班组表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.HasKey("RecordId");

                    b.ToTable("tb_班组表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_订单表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.Property<string>("业务类型");

                    b.Property<DateTime?>("交期");

                    b.Property<string>("仓");

                    b.Property<string>("制单");

                    b.Property<string>("单号");

                    b.Property<string>("备注");

                    b.Property<decimal?>("应付")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("应收")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("往来");

                    b.Property<string>("往来单号");

                    b.Property<string>("往来号");

                    b.Property<string>("报价单");

                    b.Property<DateTime?>("日期");

                    b.HasKey("RecordId");

                    b.ToTable("tb_订单表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_订单表D", b =>
                {
                    b.Property<int>("Idx")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RN");

                    b.Property<int?>("RecordId");

                    b.Property<decimal?>("个数")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("别名");

                    b.Property<decimal?>("单价")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("单位");

                    b.Property<string>("品号");

                    b.Property<string>("品名");

                    b.Property<string>("品牌");

                    b.Property<string>("型号");

                    b.Property<string>("备注");

                    b.Property<string>("子单号");

                    b.Property<decimal?>("库存")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("数量")
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime?>("新价日期");

                    b.Property<decimal?>("最新价")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("状态");

                    b.Property<decimal?>("税率")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("规格");

                    b.Property<string>("质保");

                    b.Property<decimal?>("金额")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Idx");

                    b.ToTable("tb_订单表D");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_设备表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.Property<string>("产能公式");

                    b.Property<string>("使用部门");

                    b.Property<string>("厂商");

                    b.Property<string>("名称");

                    b.Property<string>("备注");

                    b.Property<string>("属性");

                    b.Property<string>("工作日历");

                    b.Property<decimal?>("序号")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("折旧年限")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("折旧方法");

                    b.Property<string>("是否主线");

                    b.Property<string>("类型");

                    b.Property<string>("编号");

                    b.Property<string>("规格型号");

                    b.Property<DateTime?>("购置时间");

                    b.Property<decimal?>("资产原值")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("RecordId");

                    b.ToTable("tb_设备表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_证照表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.Property<string>("品号");

                    b.Property<string>("图片");

                    b.Property<int?>("图片I");

                    b.Property<string>("文件");

                    b.Property<int?>("文件A");

                    b.Property<string>("是否预警");

                    b.Property<DateTime?>("有效日");

                    b.Property<string>("档案号");

                    b.Property<string>("登记人");

                    b.Property<DateTime?>("登记日期");

                    b.Property<string>("说明");

                    b.HasKey("RecordId");

                    b.ToTable("tb_证照表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_需求表", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<bool?>("IsDeleted");

                    b.Property<DateTime?>("LastEditTime");

                    b.Property<string>("LastEditUser");

                    b.Property<int?>("LockStatus");

                    b.Property<string>("业务类型");

                    b.Property<DateTime?>("交期");

                    b.Property<string>("仓");

                    b.Property<string>("制单");

                    b.Property<string>("单号");

                    b.Property<string>("备注");

                    b.Property<string>("往来");

                    b.Property<string>("往来单号");

                    b.Property<string>("往来号");

                    b.Property<DateTime?>("日期");

                    b.HasKey("RecordId");

                    b.ToTable("tb_需求表");
                });

            modelBuilder.Entity("Pinhua2.Data.Models.tb_需求表D", b =>
                {
                    b.Property<int>("Idx")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RN");

                    b.Property<int?>("RecordId");

                    b.Property<decimal?>("个数")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("别名");

                    b.Property<decimal?>("单价")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("单位");

                    b.Property<string>("品号");

                    b.Property<string>("品名");

                    b.Property<string>("品牌");

                    b.Property<string>("型号");

                    b.Property<string>("备注");

                    b.Property<string>("子单号");

                    b.Property<decimal?>("库存")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("数量")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("状态");

                    b.Property<decimal?>("税率")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("规格");

                    b.Property<decimal?>("金额")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Idx");

                    b.ToTable("tb_需求表D");
                });
#pragma warning restore 612, 618
        }
    }
}
