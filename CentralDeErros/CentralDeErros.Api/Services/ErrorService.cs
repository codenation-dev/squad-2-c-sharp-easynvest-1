using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    public class ErrorService : IErrorService
    {

        private ErroDbContext _context;

        public ErrorService(ErroDbContext context)
        {
            this._context = context;
        }

        public bool CadastraErro(int idAmbiente, int idLevel, int idSituacao, string titulo)
        {
            _context.Errors.Add(new Error { Ambiente_Id = idAmbiente, Level_Id = idLevel, Situacao_Id = idSituacao, Titulo = titulo });

            if (_context.Errors.FirstOrDefault(e => e.Ambiente_Id == idAmbiente && e.Level_Id == idLevel && e.Situacao_Id == idSituacao && e.Titulo == titulo) != null)
            {
                return true;
            }

            return false;
        }

        public Error ConsultaErro(int id)
        {
            return _context.Errors.Find(id);
        }

    }
}
