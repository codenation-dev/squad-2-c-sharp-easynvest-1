using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros
{
    interface IError
    {
        // cadastro de novo erro que retorna se houve sucesso ou não
        bool CadastraErro(int id, int idAmbiente, int idLevel, int idSituacai, string titulo);
        
        // pesquisa po erro e o retorna se ele existe
        Error ConsultaErro(int id);
    }
}
