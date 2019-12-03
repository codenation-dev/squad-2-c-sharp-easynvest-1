using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface ILevel
    {
        bool RegisterLevel(string name);

        Level ConsultLevel(int id);

        List<Level> ConsultAllLevels();
    }
}
