using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;
using RuralAPI.Repositories;

namespace RuralAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Person Get(long id)
        {
            return _personRepository.Get(id);
        }

        public Person Create(Person Person)
        {
            return _personRepository.Create(Person);
        }

        public Person Update(long id, Person Person)
        {
            _personRepository.Update(id, Person);
            return Person;
        }
    }
}
