using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface ISituacao
    {
        bool CadastrarSituacao(string nome);

        Situacao ConsultarSituacao(int id);

        List<Situacao> ConsultarTodasSituacoes();
    }
}
