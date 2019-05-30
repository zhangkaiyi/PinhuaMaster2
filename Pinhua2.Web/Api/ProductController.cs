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

        [HttpGet("报价")]
        public JArray BaoJiaDan()
        {
            var set = from m in _pinhua2.tb_报价表.AsNoTracking()
                      join d in _pinhua2.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in _pinhua2.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where !(d.状态 ?? string.Empty).StartsWith("已")
                      select new
                      {
                          x,
                          d
                      };
            JArray json = new JArray();
            foreach (var item in set)
            {
                var jx = JObject.FromObject(item.x);
                var jd = JObject.FromObject(item.d);
                jx.Merge(jd);
                json.Add(jx);
            }

            return json;
        }

        [HttpGet("报价/{customerId}")]
        public JArray BaoJiaDan(string customerId)
        {
            var set = from m in _pinhua2.tb_报价表.AsNoTracking()
                      join d in _pinhua2.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in _pinhua2.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where m.往来号 == customerId && !(d.状态 ?? string.Empty).StartsWith("已")
                      select new
                      {
                          x,
                          d
                      };
            JArray json = new JArray();
            foreach(var item in set)
            {
                var jx = JObject.FromObject(item.x);
                var jd = JObject.FromObject(item.d);
                jx.Merge(jd);
                json.Add(jx);
            }

            return json;
        }

        // GET api/<controller>/5
        [HttpGet("baojiadan2/{customerId}")]
        public IEnumerable<object> BaoJiaDan2(string customerId)
        {
            var set = from m in _pinhua2.tb_报价表.AsNoTracking()
                      join d in _pinhua2.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                      join x in _pinhua2.tb_商品表.AsNoTracking() on d.品号 equals x.品号
                      where m.往来号 == customerId && !(d.状态 ?? string.Empty).StartsWith("已")
                      select new
                      {
                          金额 = d.金额,
                          Guid = d.Guid,
                          Idx = d.Idx,
                          RecordId = d.RecordId,
                          RN = d.RN,
                          Sequence = d.Sequence,
                          上次价 = d.上次价,
                          上次日期 = d.上次日期,
                          个数 = d.个数,
                          别名 = d.别名,
                          单价 = d.单价,
                          单位 = d.单位,
                          品号 = d.品号,
                          品名 = d.品名,
                          品牌 = d.品牌,
                          型号 = d.型号,
                          备注 = d.备注,
                          子单号 = d.子单号,
                          库存 = d.库存,
                          数量 = d.数量,
                          状态 = d.状态,
                          税率 = d.税率,
                          规格 = d.规格,
                          长度 = x.长度,
                          宽度 = x.宽度,
                          高度 = x.高度,
                          面厚 = x.面厚,
                      };
            return set.ToArray();
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
