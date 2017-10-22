using Sample.Domain.Abstract;
using Sample.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sample.API.Controllers
{
    public class HelloWorldController : ApiController
    {
        private readonly ISampleDataService _sampleDataService;

        public HelloWorldController(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public async Task<IHttpActionResult> GetSampleData()
        {
            IEnumerable<SampleData> sampleData = await _sampleDataService.GetSampleDataAsync();
            return Ok(sampleData);
        }
    }
}
