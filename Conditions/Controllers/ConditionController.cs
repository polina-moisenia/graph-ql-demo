using Microsoft.AspNetCore.Mvc;
using Conditions.Models;
using Conditions.Services;

namespace Conditions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionController : Controller
    {
        private readonly IConditionService _service;

        public ConditionController(IConditionService service)
        {
            _service = service;
        }

        [HttpGet("{movieId:length(3)}")]
        public ActionResult<Condition> Get(string movieId)
        {
            return _service.GetConditionByMovieId(movieId);
        }
    }
}