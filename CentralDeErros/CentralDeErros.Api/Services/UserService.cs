using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    public class UserService : IUserService
    {
        private ErroDbContext context;
        public UserService(ErroDbContext context)
        {
            this.context = context;
        }
        public bool Cadastrar(string email, string password, string name)
        {
            throw new NotImplementedException();
        }

        public bool Logar(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
