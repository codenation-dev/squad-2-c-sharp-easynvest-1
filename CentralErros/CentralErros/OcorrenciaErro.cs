using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros
{
    class OcorrenciaErro : IOcorrenciaErro
    {
        public bool CadastrarErro(int erroId, string origem, string detalhe, DateTime dataHora, string userToken)
        {
            throw new NotImplementedException();
        }

        public List<OcorrenciaErro> Consulta(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado)
        {
            throw new NotImplementedException();
        }

        public List<OcorrenciaErro> ListarTodasOcorrencias(int level)
        {
            throw new NotImplementedException();
        }

        public List<OcorrenciaErro> ListarTodasOcorrenciasPorLevel()
        {
            throw new NotImplementedException();
        }
    }
}
