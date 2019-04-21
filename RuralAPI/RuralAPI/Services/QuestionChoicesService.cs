using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;
using RuralAPI.Repositories;

namespace RuralAPI.Services
{
    public class QuestionChoicesService : IQuestionChoicesService
    {
        private readonly IQuestionChoicesRepository _questionChoicesRepository;

        public QuestionChoicesService(IQuestionChoicesRepository questionChoicesRepository)
        {
            _questionChoicesRepository = questionChoicesRepository;
        }

        public List<QuestionChoice> GetAll()
        {
            return _questionChoicesRepository.GetAll();
        }

        public QuestionChoice Get(long id)
        {
            return _questionChoicesRepository.Get(id);
        }
    }
}
