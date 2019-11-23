using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface IErrorService
    {
        bool RegisterError(int environmentId, int levelId, int situationId, string title);
        Error ConsultError(int id);
    }
}
