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
    public class ProductController : Controller
    {
        private readonly Pinhua2Context _pinhua2;
        public ProductController(Pinhua2Context pinhua2)
        {
            _pinhua2 = pinhua2;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<tb_商品表> Get()
        {
            return _pinhua2.tb_商品表.AsNoTracking().ToList();
        }

        [HttpGet("all")]
        public IEnumerable<tb_商品表> All()
        {
            return _pinhua2.tb_商品表.AsNoTracking().ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //[HttpGet("报价")]
        //public JArray 销售报价商品()
        //{
        //    var set = from m in _pinhua2.tb_报价表.AsNoTracking()
        //              join d in _pinhua2.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
        //              join x in _pinhua2.tb_商品表.AsNoTracking() on d.品号 equals x.品号
        //              where !(d.状态 ?? string.Empty).StartsWith("已")
        //              select new
        //              {
        //                  x,
        //                  d
        //              };
        //    JArray json = new JArray();
        //    foreach (var item in set)
        //    {
        //        var jx = JObject.FromObject(item.x);
        //        var jd = JObject.FromObject(item.d);
        //        jx.Merge(jd);
        //        json.Add(jx);
        //    }

        //    return json;
        //}

        [HttpGet("报价/all")]
        public JArray 销售报价商品()
        {
            return new JArray(_pinhua2.Get销售报价商品());
        }

        [HttpGet("报价/{customerId}")]
        public JArray 销售报价商品(string customerId)
        {
            return new JArray(_pinhua2.Get销售报价商品(customerId).Where(j => !(((string)j["状态"]) ?? string.Empty).StartsWith("已")));
        }

        [HttpGet("报价/{customerId}/{orderId}")]
        public JArray 销售报价商品(string customerId, string orderId)
        {
            return new JArray(_pinhua2.Get销售报价商品(customerId, orderId).Where(j => !(((string)j["状态"]) ?? string.Empty).StartsWith("已")));
        }


        [HttpGet("订单/{customerId}")]
        public JArray 销售订单商品(string customerId)
        {
            return _pinhua2.Get销售订单商品(customerId);
        }

        [HttpGet("出库/{customerId}/{orderId}")]
        public JArray 销售出库商品(string customerId, string orderId)
        {
            return _pinhua2.Get销售出库商品(customerId, orderId);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
