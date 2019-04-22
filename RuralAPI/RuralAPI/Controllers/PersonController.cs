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
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
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
        public ActionResult<Person> Get(long id)
        {
            var person = _personService.Get(id);
            return person;
        }

        // POST: api/People
        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            var newPerson = _personService.Create(person);

            return newPerson;
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public ActionResult<Person> Put(long id, Person person)
           {

                var updatedPerson = _personService.Update(id, person);
            return updatedPerson;
        }
    }
}
