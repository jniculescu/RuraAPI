using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RuralAPI.Repositories
{
    public class PersonRepository
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
    }
}
