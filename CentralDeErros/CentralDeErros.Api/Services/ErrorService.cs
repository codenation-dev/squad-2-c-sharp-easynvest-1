using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    public class ErrorService : IErrorService
    {
        private ErroDbContext context;
        public ErrorService(ErroDbContext context)
        {
            this.context = context;
        }
        public bool CadastraErro(int id, int idAmbiente, int idLevel, int idSituacai, string titulo)
        {
            throw new NotImplementedException();
        }

        public ErrorService ConsultaErro(int id)
        {
            throw new NotImplementedException();
        }
    }
}
