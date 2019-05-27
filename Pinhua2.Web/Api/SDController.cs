using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pinhua2.Data;
using Pinhua2.Data.Models;

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
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<tb_商品表> Get()
        {
            var items = _pinhua2.tb_商品表.AsNoTracking().ToList();
            return items;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // GET api/<controller>/5
        [HttpGet("baojiadan/{customerId}")]
        public IEnumerable<tb_报价表D> BaoJiaDan(string customerId)
        {
            var set = from m in _pinhua2.tb_报价表.AsNoTracking()
                      join d in _pinhua2.tb_报价表D.AsNoTracking() on m.RecordId equals d.RecordId
                      where m.往来号 == customerId /*&& !(d.状态 ?? string.Empty).StartsWith("已")*/
                      select d;
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
