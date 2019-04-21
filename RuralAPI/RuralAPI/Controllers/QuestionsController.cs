using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuralAPI.Services;
using RuralAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RuralAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : Controller
    {
        private IQuestionsService _questionsService;

        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        // GET api/Questions
        [HttpGet]
        public ActionResult<Question> GetAll()
        {
            var questions = _questionsService.GetAll();
            return new JsonResult(questions);
        }

        // GET api/Questions/6
        [HttpGet("{id}")]
        public ActionResult<Question> Get(long id)
        {
            var question = _questionsService.Get(id);
            return question;
        }
    }
}
