using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros
{
    interface IError
    {
        bool CadastraErro(int id, int idAmbiente, int idLevel, int idSituacai, string titulo);
        Error ConsultaErro(int id);
    }
}
