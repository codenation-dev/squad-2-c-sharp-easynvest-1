using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface IUserService
    {
        bool Cadastrar(string email, string password, string name);

        bool Logar(string email, string password);
    }
}
