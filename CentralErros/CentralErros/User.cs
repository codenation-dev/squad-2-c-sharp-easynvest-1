using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros
{
    class User : IUser
    {
        public bool cadastrar(string email, string password, string name)
        {
            throw new NotImplementedException();
        }

        public bool logar(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
