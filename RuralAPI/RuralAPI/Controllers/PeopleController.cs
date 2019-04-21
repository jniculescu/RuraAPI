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
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }



        // GET: api/People
        [HttpGet]
        public ActionResult<Person> GetAll()
        {
            var persons = _personService.GetAll();
            return new JsonResult(persons);
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(long id)
        {
            var person = await _personService.Get(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

       /* // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(long id, Person person)
        {
            if (id != person.PersonId)
            {
                return BadRequest();
            }

            _personService.Entry(person).State = EntityState.Modified;

            try
            {
                await _personService.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        } */

        // POST: api/People
        [HttpPost]
        public ActionResult<Person> Create(Person person)
        {
            _personService.Create(person);
            _personService.SaveChanges();

            return person;
        }

        /*
        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(long id)
        {
            var person = await _personService.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _personService.Person.Remove(person);
            await _personService.SaveChangesAsync();

            return person;
        }

        private bool PersonExists(long id)
        {
            return _personService.Person.Any(e => e.PersonId == id);
        } */
    }
}
