using CentralDeErros.Api.DTOs;
using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;

namespace CentralDeErros.Api.Services
{
    public interface IEnvironment
    {
        Models.Environment RegisterEnvironment (Models.Environment environment);

        Models.Environment ConsultEnvironment(int id);

        List<Models.Environment> ConsultAllEnvironments();
    }
}
