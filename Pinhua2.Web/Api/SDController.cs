using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinhua2.Web.Api
{
    [Route("api/[controller]")]
    public class SDController : Controller
    {
        private readonly Pinhua2Context _pinhua2;
        public SDController(Pinhua2Context pinhua2)
        {
            _pinhua2 = pinhua2;
        }

        [HttpGet("报价/{orderId}")]
        public JArray 报价_orderId(string orderId)
        {
            return _pinhua2.Get销售报价商品("", orderId);
        }

        [HttpGet("订单/{orderId}")]
        public JArray 订单_orderId(string orderId)
        {
            return _pinhua2.Get销售订单商品("", orderId);
        }

        [HttpGet("出库/{orderId}")]
        public JArray 出库_orderId(string orderId)
        {
            return _pinhua2.Get销售出库商品("", orderId);
        }

        [HttpGet("收款/{orderId}")]
        public JArray 收款_orderId(string orderId)
        {
            return _pinhua2.Get销售收款商品("", orderId);
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

        [HttpGet("收付待收/{customerId}")]
        public IEnumerable<object> 收付待收(string customerId)
        {
            return _pinhua2.list_收付待收(customerId);
        }

        [HttpGet("收付待付/{customerId}")]
        public IEnumerable<object> 收付待付(string customerId)
        {
            return _pinhua2.list_收付待付(customerId);
        }
    }
}
