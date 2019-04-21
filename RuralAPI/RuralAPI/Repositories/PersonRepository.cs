using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RuralAPI.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Ruraldb2Context _context;

        public PersonRepository(Ruraldb2Context context)
        {
            _context = context;
        }

        public List<Person> GetAll()
        {
             var persons = _context.Person.AsNoTracking().ToList();
            return persons;
        }

        public Person Get(long id)
        {
            return _context.Person.AsNoTracking().FirstOrDefault(p => p.PersonId == id);
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public Person Update(long id, Person person)
        {
            var personToUpdate = _context.Person.AsNoTracking().FirstOrDefault(p => p.PersonId == id);
            personToUpdate = person;
            _context.Person.Update(personToUpdate);
            _context.SaveChanges();
            return personToUpdate;
        }
    }
}
