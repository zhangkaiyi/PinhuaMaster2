﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pinhua2.Data.Helper;
using AutoMapper;
using Pinhua2.Web.Mapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinhua2.Web.Api
{
    [Route("api/[controller]")]
    public class 销售Controller : Controller
    {
        private readonly Pinhua2Context _pinhua2;
        private readonly IMapper _mapper;
        public 销售Controller(Pinhua2Context pinhua2, IMapper mapper)
        {
            _pinhua2 = pinhua2;
            _mapper = mapper;
        }

        [HttpGet("报价/{orderId}")]
        public JArray 报价_orderId(string orderId)
        {
            var set = from m in _pinhua2.tb_报价表.AsNoTracking()
                       join d in _pinhua2.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                       join x in _pinhua2.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                       where /*m.往来号 == customerId &&*/ m.业务类型 == "销售报价" && m.单号 == orderId
                       orderby d.RN
                       select _mapper.Map<tb_报价表D, vm_销售报价D>(d);

            return JArray.FromObject(set);
        }

        [HttpGet("订单/{orderId}")]
        public JArray 订单_orderId(string orderId)
        {
            var set = from m in _pinhua2.tb_订单表.AsNoTracking()
                      join d in _pinhua2.tb_订单表D.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in _pinhua2.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where m.业务类型 == "销售订单" && m.单号 == orderId
                      orderby d.RN
                      select _mapper.Map<tb_订单表D, vm_销售订单D>(d);

            return JArray.FromObject(set);
        }

        [HttpGet("出库/{orderId}")]
        public JArray 出库_orderId(string orderId)
        {
            var set = from m in _pinhua2.tb_IO.AsNoTracking()
                      join d in _pinhua2.tb_IOD.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in _pinhua2.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where m.单号 == orderId && m.类型 == "销售出库"
                      orderby d.RN
                      select _mapper.Map<tb_IOD, vm_销售出库D>(d);

            return JArray.FromObject(set);
        }

        [HttpGet("收款/{orderId}")]
        public JArray 收款_orderId(string orderId)
        {
            var set = from m in _pinhua2.tb_收付表.AsNoTracking()
                      join d in _pinhua2.tb_收付表D.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in _pinhua2.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where m.单号 == orderId && m.类型 == "收款"
                      orderby d.RN
                      select _mapper.Map<tb_收付表D, vm_收款单D>(d);

            return JArray.FromObject(set);
        }

        [HttpGet("订单待发")]
        public IEnumerable<object> 订单待发()
        {
            return _pinhua2.list_订单待发();
        }

        [HttpGet("订单待发/{customerId}")]
        public IEnumerable<object> 订单待发(string customerId)
        {
            return _pinhua2.list_订单待发(customerId);
        }

        [HttpGet("订单待收")]
        public IEnumerable<object> 订单待收()
        {
            return _pinhua2.list_订单待收();
        }

        [HttpGet("订单待收/{customerId}")]
        public IEnumerable<object> 订单待收(string customerId)
        {
            return _pinhua2.list_订单待收(customerId);
        }

        //[HttpGet("收付待收")]
        //[HttpGet("金额待收")]
        public IEnumerable<object> 收付待收()
        {
            return _pinhua2.list_收付待收();
        }

        [HttpGet("收付待收/{customerId}")]
        [HttpGet("金额待收/{customerId}")]
        public IEnumerable<object> 收付待收_customerId(string customerId)
        {
            return _pinhua2.list_收付待收(customerId);
        }

        [HttpGet("收付待付/{customerId}")]
        [HttpGet("金额待付/{customerId}")]
        public IEnumerable<object> 收付待付(string customerId)
        {
            return _pinhua2.list_收付待付(customerId);
        }
    }
}
