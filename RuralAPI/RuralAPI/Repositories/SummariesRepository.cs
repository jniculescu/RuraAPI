using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuralAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RuralAPI.Repositories
{
    public class SummariesRepository : ISummariesRepository
    {
        private readonly Ruraldb2Context _context;

        public SummariesRepository(Ruraldb2Context context)
        {
            _context = context;
        }

        public List<Summary> GetAll()
        {
           return _context.Summary.ToList();
        }

        public Summary Get(long id)
        {
           return _context.Summary.AsNoTracking().FirstOrDefault(p => p.SummaryId == id);
        }

        public Summary Create(Summary newSummary)
        {
            _context.Summary.Add(newSummary);
            _context.SaveChanges();
            return newSummary;
        }
        
        public Summary Update(long id, Summary summary)
        {
           var summaryToUpdate = _context.Summary.AsNoTracking().FirstOrDefault(p => p.SummaryId == id);
            summaryToUpdate = summary;
            _context.Summary.Update(summaryToUpdate);
            _context.SaveChanges();
            return summaryToUpdate;
        }
    }
}
