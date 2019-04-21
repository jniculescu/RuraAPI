using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;
using RuralAPI.Repositories;

namespace RuralAPI.Services
{
    public class SummariesService : ISummariesService
    {
        private readonly ISummariesRepository _summariesRepository;

        public SummariesService(ISummariesRepository summariesRepository)
        {
            _summariesRepository = summariesRepository;
        }

        public List<Summary> GetAll()
        {
            return _summariesRepository.GetAll();
        }

        public Summary Get(long id)
        {
            return _summariesRepository.Get(id);
        }

        public Summary Create(Summary summary)
        {
            return _summariesRepository.Create(summary);
        }

        public Summary Update(long id, Summary summary)
        {
           _summariesRepository.Update(id, summary);
            return summary;
        }
    }
}
