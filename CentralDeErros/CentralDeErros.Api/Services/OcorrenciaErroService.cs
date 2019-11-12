using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    public class OcorrenciaErroService : IOcorrenciaErroService
    {
        private ErroDbContext context;
        public OcorrenciaErroService(ErroDbContext context)
        {
            this.context = context;
        }
        public bool CadastrarErro(int erroId, string origem, string detalhe, DateTime dataHora, string userToken)
        {
            throw new NotImplementedException();
        }

        public List<OcorrenciaErroService> Consulta(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado)
        {
            throw new NotImplementedException();
        }

        public List<OcorrenciaErroService> ListarTodasOcorrencias(int level)
        {
            throw new NotImplementedException();
        }
    }
}
