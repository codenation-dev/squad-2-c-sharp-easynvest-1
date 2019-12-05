using CentralDeErros.Api.Models;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface IError
    {
        Error RegisterOrUpdateError(Error error, int environmentId, int levelId);

        Error ConsultError(int id);

        List<Error> ConsultAllErrors();

        bool ErrorExists(int id);
    }
}
