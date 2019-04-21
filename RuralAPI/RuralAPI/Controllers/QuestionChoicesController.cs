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
    public class QuestionChoicesController : ControllerBase
    {
        private readonly IQuestionChoicesService _questionChoicesService;

        public QuestionChoicesController(IQuestionChoicesService questionChoicesService)
        {
            _questionChoicesService = questionChoicesService;
        }

        // GET: api/QuestionChoices
        [HttpGet]
        public ActionResult<QuestionChoice> GetAll()
        {
            var Questionchoices = _questionChoicesService.GetAll().ToList();
            return new JsonResult(Questionchoices);
        }

        // GET: api/QuestionChoices/5
        [HttpGet("{id}")]
        public ActionResult<QuestionChoice> Get(long id)
        {
            var questionChoice = _questionChoicesService.Get(id);

            if (questionChoice == null)
            {
                return NotFound();
            }

            return questionChoice;
        }
    }  
}
