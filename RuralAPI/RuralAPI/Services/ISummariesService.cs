using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;
using RuralAPI.Repositories;

namespace RuralAPI.Services
{
    public interface ISummariesService
    {
        List<Summary> GetAll();
        Summary Get(long id);
        Summary Create(Summary summary);
        Summary Update(long id, Summary summary);
    }
}
