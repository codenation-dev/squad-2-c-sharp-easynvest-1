using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface IErrorService
    {
        bool CadastraErro(int id, int idAmbiente, int idLevel, int idSituacai, string titulo);
        ErrorService ConsultaErro(int id);
    }
}
