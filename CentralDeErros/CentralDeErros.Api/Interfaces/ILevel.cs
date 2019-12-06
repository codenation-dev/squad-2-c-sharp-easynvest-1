using CentralDeErros.Api.Models;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface ILevel
    {
        Level RegisterOrUpdateLevel(Level level);

        Level ConsultLevel(int id);

        List<Level> ConsultAllLevels();

        bool LevelExists(int id);
    }
}
