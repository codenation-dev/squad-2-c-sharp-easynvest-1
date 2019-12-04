using CentralDeErros.Api.Models;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    interface ISituation
    {
        bool RegisterSituation(string name);

        Situation ConsultSituation(int id);

        List<Situation> ConsultAllSituations();
    }
}
