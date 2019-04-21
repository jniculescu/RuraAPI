using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuralAPI.Repositories;
using RuralAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RuralAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : Controller
    {
        private IQuestionsRepository _questionsRepository;

        public QuestionsController(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        // GET api/Questions
        [HttpGet]
        public ActionResult<Question> GetAll()
        {
            var questions = _questionsRepository.GetAll();
            return new JsonResult(questions);
        }

        // GET api/Questions/6
        [HttpGet("{id}")]
        public ActionResult<Question> Get(long id)
        {
            var question = _questionsRepository.Get(id);
            return question;
        }
    }
}
