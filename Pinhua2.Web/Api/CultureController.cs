using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pinhua2.Web.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CultureController : Controller
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public CultureController(IStringLocalizerFactory localizerFactory, IStringLocalizer<SharedResource> localizer)
        {
            var type = typeof(SharedResource);
            _localizer = localizer;
        }

        [HttpGet]
        public string Get()
        {
            return _localizer["本地化"];
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return _localizer[id];
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
