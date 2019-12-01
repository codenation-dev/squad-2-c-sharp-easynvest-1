using System.Collections.Generic;
using System.Linq;
using CentralDeErros.Api.Models;

namespace CentralDeErros.Api.Services
{
    public class SituationService : ISituation
    {
        public ErrorDbContext _context;

        public SituationService(ErrorDbContext context)
        {
            this._context = context;
        }

        public bool RegisterSituation(string name)
        {
            _context.Situations.Add(new Situation { SituationName = name });

            if (_context.Situations.FirstOrDefault(s => s.SituationName == name) != null)
            {
                return true;
            }

            return false;
        }

        public Situation ConsultSituation(int id)
        {
            return _context.Situations.Find(id);
        }

        public List<Situation> ConsultAllSituations()
        {
            return _context.Situations.Select(s => s).ToList();
        }
    }
}
