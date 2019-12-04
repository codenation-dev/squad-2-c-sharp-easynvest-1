using CentralDeErros.Api.Models;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface ISituation
    {
        Situation RegisterOrUpdateSituation(Situation situation);

        Situation ConsultSituation(int id);

        List<Situation> ConsultAllSituations();

        bool SituationExists(int id);
    }
}
