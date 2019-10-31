using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros
{
    interface IOcorrenciaErro
    {
        // cadastra e retorna sucesso ou falha
        bool CadastrarErro(int erroId, string origem, string detalhe, DateTime dataHora, string userToken);

        // retorna a lista (detalhada) de todos os erros de um tipo de level individualmente
        List<OcorrenciaErro> ListarTodasOcorrencias(int level);

        // retorna a lista (detalhada) dos erros agrupados de acordo com o level e a quantidade de vezes que ele repete sem filtragem de dados
        List<OcorrenciaErro> ListarTodasOcorrenciasPorLevel();

        // retorna a lista (resumida) dos erros agrupados de acordo com o level e a quantidade de vezes que ele repete com filtragem dos dados
        List<OcorrenciaErro> Consulta(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);



    }
}
