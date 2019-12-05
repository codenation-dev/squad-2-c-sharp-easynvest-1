using CentralDeErros.Api.Models;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface IError
    {
        Error RegisterOrUpdateError(Error error);

        Error ConsultError(int id);

        List<Error> ConsultAllErrors();

        bool ErrorExists(int id);
    }
}
