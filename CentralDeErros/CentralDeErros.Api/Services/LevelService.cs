using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralDeErros.Api.Interfaces;
using CentralDeErros.Api.Models;

namespace CentralDeErros.Api.Services
{
    public class LevelService : ILevel
    {
        public ErrorDbContext _context;

        public LevelService(ErrorDbContext context)
        {
            this._context = context;
        }

        public Level RegisterLevel(Level level)
        {
            _context.Levels.Add(new Level { LevelName = name });

            if (_context.Levels.FirstOrDefault(l => l.LevelName == name) != null)
            {
                return true;
            }

            return false;
        }

        public Level ConsultLevel(int id)
        {
            return _context.Levels.Find(id);
        }

        public List<Level> ConsultAllLevels()
        {
            return _context.Levels.Select(l => l).ToList();
        }
    }
}
