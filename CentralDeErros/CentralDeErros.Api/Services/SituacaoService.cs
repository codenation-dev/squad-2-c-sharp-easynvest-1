using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralDeErros.Api.Models;

namespace CentralDeErros.Api.Services
{
    public class SituacaoService : ISituacao
    {
        public ErroDbContext _context;

        public SituacaoService(ErroDbContext context)
        {
            this._context = context;
        }

        public bool CadastrarSituacao(string nome)
        {
            _context.Situacoes.Add(new Situacao { Nome_Situacao = nome });

            if (_context.Situacoes.FirstOrDefault(s => s.Nome_Situacao == nome) != null)
            {
                return true;
            }

            return false;
        }

        public Situacao ConsultarSituacao(int id)
        {
            return _context.Situacoes.Find(id);
        }

        public List<Situacao> ConsultarTodasSituacoes()
        {
            return _context.Situacoes.Select(s => s).ToList();
        }
    }
}
