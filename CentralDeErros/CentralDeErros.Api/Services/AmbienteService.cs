using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    public class AmbienteService : IAmbiente
    {
        public ErroDbContext _context;

        public AmbienteService(ErroDbContext context)
        {
            this._context = context;
        }

        public bool CadastrarAmbiente(string nome)
        {
            _context.Ambientes.Add(new Ambiente { Nome_Ambiente = nome });

            if (_context.Ambientes.FirstOrDefault(a => a.Nome_Ambiente == nome) != null)
            {
                return true;
            }

            return false;
        }

        public Ambiente ConsultarAmbiente(int id)
        {
            return _context.Ambientes.Find(id);
        }

        public List<Ambiente> ConsultarTodosAmbientes()
        {
            return _context.Ambientes.Select(a => a).ToList();
        }
    }
}
