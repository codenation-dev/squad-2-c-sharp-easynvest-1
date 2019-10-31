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

        // retorna 
        List<OcorrenciaErro> Consulta(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);



    }
}
