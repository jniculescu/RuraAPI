using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;

namespace RuralAPI.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private Ruraldb2Context _context;

        public QuestionsRepository(Ruraldb2Context context)
        {
            _context = context;
        }

        public List<Question> GetAllQuestions ()
        {
           return _context.Question.ToList();
        }
    }
}
