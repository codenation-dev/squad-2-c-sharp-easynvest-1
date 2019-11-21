using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface IAmbiente
    {
        bool CadastrarAmbiente(string nome);
        
        Ambiente ConsultarAmbiente(int id);

        List<Ambiente> ConsultarTodosAmbientes();
    }
}
