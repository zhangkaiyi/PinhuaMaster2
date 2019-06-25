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
    public class MMController : Controller
    {
        private readonly Pinhua2Context _pinhua2;
        public MMController(Pinhua2Context pinhua2)
        {
            _pinhua2 = pinhua2;
        }

        [HttpGet("订单")]
        public JArray 订单_null()
        {
            return _pinhua2.Get采购订单商品("", null);
        }

        [HttpGet("订单/{orderId}")]
        public JArray 订单_orderId(string orderId)
        {
            return _pinhua2.Get采购订单商品("", orderId);
        }

        [HttpGet("询价/{orderId}")]
        public JArray 询价_orderId(string orderId)
        {
            return _pinhua2.Get采购询价商品("", orderId);
        }

        [HttpGet("申请/{orderId}")]
        public JArray 申请_orderId(string orderId)
        {
            return _pinhua2.Get采购申请商品("", orderId);
        }

    }
}
