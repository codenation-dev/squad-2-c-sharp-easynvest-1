using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface IErrorService
    {
        bool CadastraErro(int idAmbiente, int idLevel, int idSituacao, string titulo);
        Error ConsultaErro(int id);
    }
}
