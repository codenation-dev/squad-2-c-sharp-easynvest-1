using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface IOcorrenciaErroService
    {
        // cadastra e retorna sucesso ou falha
        bool CadastrarErro(Error error, User user, string origem, string detalhe, DateTime dataHora, string userToken);

        // retorna a lista (detalhada) de todos os erros de um tipo de level individualmente
        List<OcorrenciaErro> ListarOcorrenciasPorLevel(int level);

        // retorna 
        List<OcorrenciaErro> Consulta(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);

    }
}
