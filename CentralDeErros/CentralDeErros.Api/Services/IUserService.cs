using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface IUserService
    {
        bool RegisterUser(string email, string password, string name);

        bool Login(string email, string password);
    }
}
