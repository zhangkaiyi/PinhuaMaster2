﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pinhua2.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sysAutoCode",
                columns: table => new
                {
                    AutoCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutoCodeName = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    SysVar = table.Column<int>(nullable: true),
                    DateType = table.Column<string>(nullable: true),
                    SeedLength = table.Column<int>(nullable: true),
                    SeedStart = table.Column<int>(nullable: true),
                    RunBeforeSave = table.Column<int>(nullable: true),
                    AllowMore = table.Column<int>(nullable: true),
                    AllowBatch = table.Column<int>(nullable: true),
                    ReuseType = table.Column<int>(nullable: true),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<int>(nullable: true),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sysAutoCode", x => x.AutoCodeId);
                });

            migrationBuilder.CreateTable(
                name: "sysAutoCodeRegister",
                columns: table => new
                {
                    Idx = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutoCodeId = table.Column<int>(nullable: true),
                    CurrentSeed = table.Column<int>(nullable: true),
                    PrimaryPart = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sysAutoCodeRegister", x => x.Idx);
                });

            migrationBuilder.CreateTable(
                name: "sysIO",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true),
                    单号 = table.Column<string>(nullable: true),
                    日期 = table.Column<DateTime>(nullable: true),
                    制单 = table.Column<string>(nullable: true),
                    仓 = table.Column<string>(nullable: true),
                    订单号 = table.Column<string>(nullable: true),
                    往来 = table.Column<string>(nullable: true),
                    往来号 = table.Column<string>(nullable: true),
                    备注 = table.Column<string>(nullable: true),
                    类型 = table.Column<string>(nullable: true),
                    退单 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    物流单号 = table.Column<string>(nullable: true),
                    保修类型 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sysIO", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sysIO_D",
                columns: table => new
                {
                    Idx = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: true),
                    行号 = table.Column<string>(nullable: true),
                    子单号 = table.Column<string>(nullable: true),
                    订单号 = table.Column<string>(nullable: true),
                    品号 = table.Column<string>(nullable: true),
                    品名 = table.Column<string>(nullable: true),
                    品牌 = table.Column<string>(nullable: true),
                    单位 = table.Column<string>(nullable: true),
                    单价 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    金额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    税率 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    备注 = table.Column<string>(nullable: true),
                    质保 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    批次 = table.Column<string>(nullable: true),
                    条码 = table.Column<string>(nullable: true),
                    规格 = table.Column<string>(nullable: true),
                    库位 = table.Column<string>(nullable: true),
                    库存 = table.Column<string>(nullable: true),
                    仓 = table.Column<string>(nullable: true),
                    发 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    日期 = table.Column<DateTime>(nullable: true),
                    收 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    计划数 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    已完数 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    版本号 = table.Column<string>(nullable: true),
                    日期唛 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sysIO_D", x => x.Idx);
                });

            migrationBuilder.CreateTable(
                name: "sys班组表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys班组表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys报价表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true),
                    单号 = table.Column<string>(nullable: true),
                    往来单号 = table.Column<string>(nullable: true),
                    业务类型 = table.Column<string>(nullable: true),
                    仓 = table.Column<string>(nullable: true),
                    日期 = table.Column<DateTime>(nullable: true),
                    交期 = table.Column<DateTime>(nullable: true),
                    备注 = table.Column<string>(nullable: true),
                    制单 = table.Column<string>(nullable: true),
                    往来 = table.Column<string>(nullable: true),
                    往来号 = table.Column<string>(nullable: true),
                    需求单 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys报价表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys报价表_D",
                columns: table => new
                {
                    Idx = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: true),
                    行号 = table.Column<string>(nullable: true),
                    子单号 = table.Column<string>(nullable: true),
                    品号 = table.Column<string>(nullable: true),
                    品名 = table.Column<string>(nullable: true),
                    规格 = table.Column<string>(nullable: true),
                    库存 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    单位 = table.Column<string>(nullable: true),
                    数量 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    单价 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    金额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    税率 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    备注 = table.Column<string>(nullable: true),
                    上次价 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    上次日期 = table.Column<DateTime>(nullable: true),
                    品牌 = table.Column<string>(nullable: true),
                    状态 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys报价表_D", x => x.Idx);
                });

            migrationBuilder.CreateTable(
                name: "sys订单表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true),
                    单号 = table.Column<string>(nullable: true),
                    往来单号 = table.Column<string>(nullable: true),
                    业务类型 = table.Column<string>(nullable: true),
                    仓 = table.Column<string>(nullable: true),
                    日期 = table.Column<DateTime>(nullable: true),
                    交期 = table.Column<DateTime>(nullable: true),
                    备注 = table.Column<string>(nullable: true),
                    制单 = table.Column<string>(nullable: true),
                    往来 = table.Column<string>(nullable: true),
                    往来号 = table.Column<string>(nullable: true),
                    报价单 = table.Column<string>(nullable: true),
                    应收 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    应付 = table.Column<decimal>(type: "decimal(18,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys订单表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys订单表_D",
                columns: table => new
                {
                    Idx = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: true),
                    行号 = table.Column<string>(nullable: true),
                    子单号 = table.Column<string>(nullable: true),
                    品号 = table.Column<string>(nullable: true),
                    品名 = table.Column<string>(nullable: true),
                    规格 = table.Column<string>(nullable: true),
                    库存 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    单位 = table.Column<string>(nullable: true),
                    数量 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    单价 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    金额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    税率 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    备注 = table.Column<string>(nullable: true),
                    最新价 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    新价日期 = table.Column<DateTime>(nullable: true),
                    品牌 = table.Column<string>(nullable: true),
                    状态 = table.Column<string>(nullable: true),
                    质保 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys订单表_D", x => x.Idx);
                });

            migrationBuilder.CreateTable(
                name: "sys付款条件表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys付款条件表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys工序表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys工序表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys商品表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true),
                    填报时间 = table.Column<DateTime>(nullable: true),
                    品号 = table.Column<string>(nullable: true),
                    品名 = table.Column<string>(nullable: true),
                    拼音码 = table.Column<string>(nullable: true),
                    规格 = table.Column<string>(nullable: true),
                    库位 = table.Column<string>(nullable: true),
                    单位 = table.Column<string>(nullable: true),
                    分类1 = table.Column<string>(nullable: true),
                    分类2 = table.Column<string>(nullable: true),
                    安全库存 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    状态 = table.Column<string>(nullable: true),
                    复制 = table.Column<string>(nullable: true),
                    大类 = table.Column<string>(nullable: true),
                    别名 = table.Column<string>(nullable: true),
                    材质 = table.Column<string>(nullable: true),
                    表面处理 = table.Column<string>(nullable: true),
                    换算单位 = table.Column<string>(nullable: true),
                    换算系数 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    单重 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    色号 = table.Column<string>(nullable: true),
                    客户号 = table.Column<string>(nullable: true),
                    客户 = table.Column<string>(nullable: true),
                    销售价 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    指定销售价 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    供应商号 = table.Column<string>(nullable: true),
                    供应商 = table.Column<string>(nullable: true),
                    采购价 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    最新采购价 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    采购周期 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    客户料号 = table.Column<string>(nullable: true),
                    计算公式 = table.Column<string>(nullable: true),
                    档案号 = table.Column<string>(nullable: true),
                    是否共用 = table.Column<string>(nullable: true),
                    上级品号 = table.Column<string>(nullable: true),
                    配比值 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    版本号 = table.Column<string>(nullable: true),
                    条码 = table.Column<string>(nullable: true),
                    备注 = table.Column<string>(nullable: true),
                    图片 = table.Column<string>(nullable: true),
                    图片I = table.Column<int>(nullable: true),
                    品牌 = table.Column<string>(nullable: true),
                    正面颜色 = table.Column<string>(nullable: true),
                    反面颜色 = table.Column<string>(nullable: true),
                    商品信息 = table.Column<string>(nullable: true),
                    是否新旧 = table.Column<string>(nullable: true),
                    链接 = table.Column<string>(nullable: true),
                    是否采购 = table.Column<string>(nullable: true),
                    是否销售 = table.Column<string>(nullable: true),
                    是否存储 = table.Column<string>(nullable: true),
                    是否卷筒 = table.Column<string>(nullable: true),
                    上级品名 = table.Column<string>(nullable: true),
                    质保 = table.Column<decimal>(type: "decimal(18,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys商品表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys设备表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true),
                    编号 = table.Column<string>(nullable: true),
                    名称 = table.Column<string>(nullable: true),
                    规格型号 = table.Column<string>(nullable: true),
                    类型 = table.Column<string>(nullable: true),
                    厂商 = table.Column<string>(nullable: true),
                    属性 = table.Column<string>(nullable: true),
                    序号 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    产能公式 = table.Column<string>(nullable: true),
                    资产原值 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    折旧方法 = table.Column<string>(nullable: true),
                    折旧年限 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    使用部门 = table.Column<string>(nullable: true),
                    购置时间 = table.Column<DateTime>(nullable: true),
                    工作日历 = table.Column<string>(nullable: true),
                    是否主线 = table.Column<string>(nullable: true),
                    备注 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys设备表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys收付表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true),
                    类型 = table.Column<string>(nullable: true),
                    往来 = table.Column<string>(nullable: true),
                    往来号 = table.Column<string>(nullable: true),
                    收 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    付 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    单号 = table.Column<string>(nullable: true),
                    日期 = table.Column<DateTime>(nullable: true),
                    制单 = table.Column<string>(nullable: true),
                    备注 = table.Column<string>(nullable: true),
                    分配 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    发票号 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys收付表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys收付表_D",
                columns: table => new
                {
                    Idx = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: true),
                    子单号 = table.Column<string>(nullable: true),
                    数量 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    金额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    收发数 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    收发额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    已收付款数 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    已收付款额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    本次收数 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    本次收额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    本次付数 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    本次付额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    备注 = table.Column<string>(nullable: true),
                    描述 = table.Column<string>(nullable: true),
                    单位 = table.Column<string>(nullable: true),
                    可收付款额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    待收付款额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys收付表_D", x => x.Idx);
                });

            migrationBuilder.CreateTable(
                name: "sys往来表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true),
                    往来号 = table.Column<string>(nullable: true),
                    简称 = table.Column<string>(nullable: true),
                    全称 = table.Column<string>(nullable: true),
                    联系人 = table.Column<string>(nullable: true),
                    联系电话 = table.Column<string>(nullable: true),
                    公司电话 = table.Column<string>(nullable: true),
                    传真 = table.Column<string>(nullable: true),
                    Qq = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    地址 = table.Column<string>(nullable: true),
                    开户行 = table.Column<string>(nullable: true),
                    组织代码 = table.Column<string>(nullable: true),
                    账号 = table.Column<string>(nullable: true),
                    状态 = table.Column<string>(nullable: true),
                    登记部门 = table.Column<string>(nullable: true),
                    类型 = table.Column<string>(nullable: true),
                    币种 = table.Column<string>(nullable: true),
                    负责人 = table.Column<string>(nullable: true),
                    付款方式 = table.Column<string>(nullable: true),
                    税收组 = table.Column<string>(nullable: true),
                    信用额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    登记日期 = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys往来表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys往来表_地址",
                columns: table => new
                {
                    Idx = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: true),
                    往来号 = table.Column<string>(nullable: true),
                    地址 = table.Column<string>(nullable: true),
                    联系人 = table.Column<string>(nullable: true),
                    电话 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys往来表_地址", x => x.Idx);
                });

            migrationBuilder.CreateTable(
                name: "sys往来表_开票",
                columns: table => new
                {
                    Idx = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: true),
                    往来号 = table.Column<string>(nullable: true),
                    发票抬头 = table.Column<string>(nullable: true),
                    账号 = table.Column<string>(nullable: true),
                    税号 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys往来表_开票", x => x.Idx);
                });

            migrationBuilder.CreateTable(
                name: "sys往来表_联系人",
                columns: table => new
                {
                    Idx = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: true),
                    往来号 = table.Column<string>(nullable: true),
                    联系人 = table.Column<string>(nullable: true),
                    部门 = table.Column<string>(nullable: true),
                    职位 = table.Column<string>(nullable: true),
                    电话 = table.Column<string>(nullable: true),
                    手机 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    传真 = table.Column<string>(nullable: true),
                    Qq = table.Column<string>(nullable: true),
                    备注 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys往来表_联系人", x => x.Idx);
                });

            migrationBuilder.CreateTable(
                name: "sys需求表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true),
                    单号 = table.Column<string>(nullable: true),
                    往来单号 = table.Column<string>(nullable: true),
                    业务类型 = table.Column<string>(nullable: true),
                    仓 = table.Column<string>(nullable: true),
                    日期 = table.Column<DateTime>(nullable: true),
                    交期 = table.Column<DateTime>(nullable: true),
                    备注 = table.Column<string>(nullable: true),
                    制单 = table.Column<string>(nullable: true),
                    往来 = table.Column<string>(nullable: true),
                    往来号 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys需求表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys需求表_D",
                columns: table => new
                {
                    Idx = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: true),
                    行号 = table.Column<string>(nullable: true),
                    子单号 = table.Column<string>(nullable: true),
                    品号 = table.Column<string>(nullable: true),
                    品名 = table.Column<string>(nullable: true),
                    规格 = table.Column<string>(nullable: true),
                    库存 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    单位 = table.Column<string>(nullable: true),
                    数量 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    单价 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    金额 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    税率 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    备注 = table.Column<string>(nullable: true),
                    品牌 = table.Column<string>(nullable: true),
                    状态 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys需求表_D", x => x.Idx);
                });

            migrationBuilder.CreateTable(
                name: "sys员工表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true),
                    工号 = table.Column<string>(nullable: true),
                    姓名 = table.Column<string>(nullable: true),
                    部门 = table.Column<string>(nullable: true),
                    职位 = table.Column<string>(nullable: true),
                    手机 = table.Column<string>(nullable: true),
                    电话 = table.Column<string>(nullable: true),
                    宅电 = table.Column<string>(nullable: true),
                    学历 = table.Column<string>(nullable: true),
                    婚姻 = table.Column<string>(nullable: true),
                    生日 = table.Column<DateTime>(nullable: true),
                    状态 = table.Column<string>(nullable: true),
                    入职日期 = table.Column<DateTime>(nullable: true),
                    离职日期 = table.Column<DateTime>(nullable: true),
                    是否签合同 = table.Column<string>(nullable: true),
                    合同签订日期 = table.Column<DateTime>(nullable: true),
                    合同到期日期 = table.Column<DateTime>(nullable: true),
                    是否购社保 = table.Column<string>(nullable: true),
                    社保开始日期 = table.Column<DateTime>(nullable: true),
                    社保退交日期 = table.Column<DateTime>(nullable: true),
                    基本工资 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    属性 = table.Column<string>(nullable: true),
                    身份证号 = table.Column<string>(nullable: true),
                    性别 = table.Column<string>(nullable: true),
                    地址 = table.Column<string>(nullable: true),
                    紧急联系人 = table.Column<string>(nullable: true),
                    紧急联系方式 = table.Column<string>(nullable: true),
                    紧急联系人关系 = table.Column<string>(nullable: true),
                    紧急联系人地址 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys员工表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys证照表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true),
                    品号 = table.Column<string>(nullable: true),
                    文件 = table.Column<string>(nullable: true),
                    文件A = table.Column<int>(nullable: true),
                    图片 = table.Column<string>(nullable: true),
                    图片I = table.Column<int>(nullable: true),
                    说明 = table.Column<string>(nullable: true),
                    有效日 = table.Column<DateTime>(nullable: true),
                    是否预警 = table.Column<string>(nullable: true),
                    登记人 = table.Column<string>(nullable: true),
                    登记日期 = table.Column<DateTime>(nullable: true),
                    档案号 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys证照表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys字典表",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateOrg = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EditingUser = table.Column<int>(nullable: true),
                    LastEditUser = table.Column<int>(nullable: true),
                    LastEditTime = table.Column<DateTime>(nullable: true),
                    ReportStatus = table.Column<int>(nullable: true),
                    LockStatus = table.Column<int>(nullable: true),
                    WorkflowStatus = table.Column<string>(nullable: true),
                    字典名 = table.Column<string>(nullable: true),
                    组 = table.Column<string>(nullable: true),
                    创建人 = table.Column<string>(nullable: true),
                    创建日 = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys字典表", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "sys字典表_D",
                columns: table => new
                {
                    Idx = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: true),
                    RN = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    名称 = table.Column<string>(nullable: true),
                    描述 = table.Column<string>(nullable: true),
                    代码 = table.Column<string>(nullable: true),
                    字典名 = table.Column<string>(nullable: true),
                    组 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys字典表_D", x => x.Idx);
                });

            migrationBuilder.InsertData(
                table: "sysAutoCode",
                columns: new[] { "AutoCodeId", "AllowBatch", "AllowMore", "AutoCodeName", "CreateTime", "CreateUser", "DateType", "IsActive", "Memo", "Prefix", "ReuseType", "RunBeforeSave", "SeedLength", "SeedStart", "SysVar" },
                values: new object[] { 100, null, null, "订单号", null, 2, "yyMMdd", 1, null, null, null, 1, 4, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sysAutoCode");

            migrationBuilder.DropTable(
                name: "sysAutoCodeRegister");

            migrationBuilder.DropTable(
                name: "sysIO");

            migrationBuilder.DropTable(
                name: "sysIO_D");

            migrationBuilder.DropTable(
                name: "sys班组表");

            migrationBuilder.DropTable(
                name: "sys报价表");

            migrationBuilder.DropTable(
                name: "sys报价表_D");

            migrationBuilder.DropTable(
                name: "sys订单表");

            migrationBuilder.DropTable(
                name: "sys订单表_D");

            migrationBuilder.DropTable(
                name: "sys付款条件表");

            migrationBuilder.DropTable(
                name: "sys工序表");

            migrationBuilder.DropTable(
                name: "sys商品表");

            migrationBuilder.DropTable(
                name: "sys设备表");

            migrationBuilder.DropTable(
                name: "sys收付表");

            migrationBuilder.DropTable(
                name: "sys收付表_D");

            migrationBuilder.DropTable(
                name: "sys往来表");

            migrationBuilder.DropTable(
                name: "sys往来表_地址");

            migrationBuilder.DropTable(
                name: "sys往来表_开票");

            migrationBuilder.DropTable(
                name: "sys往来表_联系人");

            migrationBuilder.DropTable(
                name: "sys需求表");

            migrationBuilder.DropTable(
                name: "sys需求表_D");

            migrationBuilder.DropTable(
                name: "sys员工表");

            migrationBuilder.DropTable(
                name: "sys证照表");

            migrationBuilder.DropTable(
                name: "sys字典表");

            migrationBuilder.DropTable(
                name: "sys字典表_D");
        }
    }
}
