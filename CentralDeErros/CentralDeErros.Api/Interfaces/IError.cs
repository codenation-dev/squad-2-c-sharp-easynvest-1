﻿using CentralDeErros.Api.Models;

namespace CentralDeErros.Api.Interfaces
{
    interface IError
    {
        bool RegisterError(int environmentId, int levelId, int situationId, string title);
        Error ConsultError(int id);
    }
}