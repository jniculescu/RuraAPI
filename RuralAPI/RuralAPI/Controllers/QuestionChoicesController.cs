using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuralAPI.Models;

namespace RuralAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionChoicesController : ControllerBase
    {
        private readonly Ruraldb2Context _context;

        public QuestionChoicesController(Ruraldb2Context context)
        {
            _context = context;
        }

        // GET: api/QuestionChoices
        [HttpGet]
        public ActionResult<IEnumerable<QuestionChoice>> GetQuestionChoice()
        {
            var Questionchoices = _context.QuestionChoice.ToList();
            return new JsonResult(Questionchoices);
        }

        // GET: api/QuestionChoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionChoice>> GetQuestionChoice(long id)
        {
            var questionChoice = await _context.QuestionChoice.FindAsync(id);

            if (questionChoice == null)
            {
                return NotFound();
            }

            return questionChoice;
        }

        // PUT: api/QuestionChoices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionChoice(long id, QuestionChoice questionChoice)
        {
            if (id != questionChoice.QuestionChoiseId)
            {
                return BadRequest();
            }

            _context.Entry(questionChoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionChoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QuestionChoices
        [HttpPost]
        public async Task<ActionResult<QuestionChoice>> PostQuestionChoice(QuestionChoice questionChoice)
        {
            _context.QuestionChoice.Add(questionChoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionChoice", new { id = questionChoice.QuestionChoiseId }, questionChoice);
        }

        // DELETE: api/QuestionChoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestionChoice>> DeleteQuestionChoice(long id)
        {
            var questionChoice = await _context.QuestionChoice.FindAsync(id);
            if (questionChoice == null)
            {
                return NotFound();
            }

            _context.QuestionChoice.Remove(questionChoice);
            await _context.SaveChangesAsync();

            return questionChoice;
        }

        private bool QuestionChoiceExists(long id)
        {
            return _context.QuestionChoice.Any(e => e.QuestionChoiseId == id);
        }
    }
}
