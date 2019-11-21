using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralDeErros.Api.Models;

namespace CentralDeErros.Api.Services
{
    public class LevelService : ILevel
    {
        public ErroDbContext _context;

        public LevelService(ErroDbContext context)
        {
            this._context = context;
        }

        public bool CadastrarLevel(string nome)
        {
            _context.Levels.Add(new Level { Nome_Level = nome });

            if (_context.Levels.FirstOrDefault(l => l.Nome_Level == nome) != null)
            {
                return true;
            }

            return false;
        }

        public Level ConsultarLevel(int id)
        {
            return _context.Levels.Find(id);
        }

        public List<Level> ConsultarTodosLevels()
        {
            return _context.Levels.Select(l => l).ToList();
        }
    }
}
