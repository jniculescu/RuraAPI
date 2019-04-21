using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;

namespace RuralAPI.Repositories
{
    public interface ISummariesRepository
    {
        List<Summary> GetAll();
        Summary Get(long id);
        Summary Create(Summary newSummary);
        Summary Update(long id, Summary summary);
    }
}
