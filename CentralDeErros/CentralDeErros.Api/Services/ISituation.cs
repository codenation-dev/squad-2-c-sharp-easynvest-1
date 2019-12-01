using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;

namespace CentralDeErros.Api.Services
{
    interface ISituation
    {
        bool RegisterSituation(string name);

        Situation ConsultSituation(int id);

        List<Situation> ConsultAllSituations();
    }
}
