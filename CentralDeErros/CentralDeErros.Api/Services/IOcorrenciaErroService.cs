using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface IOcorrenciaErroService
    {
        // cadastra e retorna sucesso ou falha
        bool CadastrarErro(int erroId, string origem, string detalhe, DateTime dataHora, string userToken);

        // retorna a lista (detalhada) de todos os erros de um tipo de level individualmente
        List<OcorrenciaErroService> ListarTodasOcorrencias(int level);

        // retorna 
        List<OcorrenciaErroService> Consulta(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);
    }
}
