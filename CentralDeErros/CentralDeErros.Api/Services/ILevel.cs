using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface ILevel
    {
        bool CadastrarLevel(string nome);

        Level ConsultarLevel(int id);

        List<Level> ConsultarTodosLevels();
    }
}
