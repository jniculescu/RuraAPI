using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RuralAPI.Repositories
{
    public class QuestionChoicesRepository : IQuestionChoicesRepository
    {
        private readonly Ruraldb2Context _context;

        public QuestionChoicesRepository(Ruraldb2Context context)
        {
            _context = context;
        }

        public List<QuestionChoice> GetAll()
        {
           return _context.QuestionChoice.AsNoTracking().ToList();
        }
       
        public QuestionChoice Get(long id)
        {
            return _context.QuestionChoice.AsNoTracking().FirstOrDefault(p => p.QuestionChoiseId == id);
        }
    }
}
