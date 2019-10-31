using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros
{
    class Error : IError
    {
        public bool CadastraErro(int id, int idAmbiente, int idLevel, int idSituacai, string titulo)
        {
            throw new NotImplementedException();
        }

        public Error ConsultaErro(int id)
        {
            throw new NotImplementedException();
        }
    }
}
