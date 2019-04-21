using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuralAPI.Models;
using RuralAPI.Services;

namespace RuralAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummariesController : ControllerBase
    {
        private readonly ISummariesService _summariesService;

        public SummariesController(ISummariesService summariesService)
        {
            _summariesService = summariesService;
        }

        // GET: api/Summaries
        [HttpGet]
        public ActionResult<Summary> GetAll()
        {
            var summaries = _summariesService.GetAll().ToList();
            return new JsonResult(summaries);
        }

        // GET: api/Summaries/5
        [HttpGet("{id}")]
        public ActionResult<Summary> Get(long id)
        {
            var summary = _summariesService.Get(id);

            return summary;
        }

        // POST: api/Summaries
        [HttpPost]
        public ActionResult<Summary> Create(Summary summary)
        {
            var newSummary = _summariesService.Create(summary);
            return newSummary;
        }

        // PUT: api/Summaries/5
        [HttpPut("{id}")]
        public ActionResult<Summary> Update(long id, Summary summary)
        {
            var updatedSummary = _summariesService.Update(id, summary);
            return updatedSummary;
        }
   
    }
}
