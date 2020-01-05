using Microsoft.AspNetCore.Mvc;
using Rates.Models;
using Rates.Services;

namespace Rates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : Controller
    {
        private readonly IRateService _service;

        public RateController(IRateService service)
        {
            _service = service;
        }

        [HttpGet("{movieId:length(3)}/{source}")]
        public ActionResult<double> Get(string movieId, RateSource source)
        {
            return _service.GetRate(movieId, source);
        }
    }
}