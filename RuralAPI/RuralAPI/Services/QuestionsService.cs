using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;
using RuralAPI.Repositories;

namespace RuralAPI.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _questionsRepository;

        public QuestionsService(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public List<Question> GetAll()
        {
            return _questionsRepository.GetAll();
        }

        public Question Get(long id)
        {
            return _questionsRepository.Get(id);
        }
    }
}
