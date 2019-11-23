using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;

namespace CentralDeErros.Api.Services
{
    interface IEnvironment
    {
        bool RegisterEnvironment (string name);

        Models.Environment ConsultEnvironment(int id);

        List<Models.Environment> ConsultAllEnvironments();
    }
}
