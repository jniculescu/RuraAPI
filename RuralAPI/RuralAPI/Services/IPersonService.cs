using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;

namespace RuralAPI.Services
{
    public interface IPersonService
    {
        List<Person> GetAll();
        Person Get(long id);
        Person Create(Person person);
        Person Update(long id, Person person);
    }
}
