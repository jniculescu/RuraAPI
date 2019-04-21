using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public List<Question> GetAll()
        {
           return _context.Question.ToList();
        }

        public Question Get(long id)
        {
            return _context.Question.AsNoTracking().FirstOrDefault(p => p.QuestionId == id);
        }
    }
}
