using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros
{
    interface IUser
    {
        bool cadastrar(string email, string password, string name);

        bool logar(string email, string password);
    }
}
