﻿using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    public class UserService : IUserService
    {
        private ErroDbContext _context;

        public bool Cadastrar(string email, string password, string name)
        {
            _context.Users.Add(new User { Email = email, Password = password, Name = name });

            if (_context.Users.FirstOrDefault(u => u.Email == email && u.Password == password && u.Name == name) != null)
            {
                return true;
            }

            return false;
        }

        public bool Logar(string email, string password)
        {
            // método para se pensar 
            // aqui deve permitir a autenticação do usuário para utilizar a api que criarmos
            throw new NotImplementedException();
        }
    }
}