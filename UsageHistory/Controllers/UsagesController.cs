using System.Collections.Generic;
using UsageHistory.Models;
using UsageHistory.Services;
using Microsoft.AspNetCore.Mvc;

namespace UsageHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsagesController : Controller
    {
        private readonly IUsagesService _usagesService;

        public UsagesController(IUsagesService usagesService)
        {
            _usagesService = usagesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usage>> Get() => _usagesService.Get();

        [HttpGet("{id:length(3)}")]
        public ActionResult<Usage> Get(string id)
        {
            var usage = _usagesService.Get(id);

            if (usage == null)
            {
                return NotFound();
            }

            return usage;
        }

        [HttpPost]
        public ActionResult<Usage> Create(Usage usage)
        {
            _usagesService.Create(usage);

            return CreatedAtRoute("GetUsage", new { id = usage.UsageId.ToString() }, usage);
        }

        [HttpPut("{id:length(3)}")]
        public IActionResult Update(string id, Usage usageIn)
        {
            var usage = _usagesService.Get(id);

            if (usage == null)
            {
                return NotFound();
            }

            _usagesService.Update(id, usageIn);

            return NoContent();
        }

        [HttpDelete("{id:length(3)}")]
        public IActionResult Delete(string id)
        {
            var usage = _usagesService.Get(id);

            if (usage == null)
            {
                return NotFound();
            }

            _usagesService.Remove(usage.Id);

            return NoContent();
        }
    }
}