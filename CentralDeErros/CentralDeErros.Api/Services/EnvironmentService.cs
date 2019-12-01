using CentralDeErros.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    public class EnvironmentService : IEnvironment
    {
        public ErrorDbContext _context;

        public EnvironmentService(ErrorDbContext context)
        {
            this._context = context;
        }

        public Models.Environment RegisterEnvironment(Models.Environment environment)
        {
            //_context.Environments.Add(new Models.Environment { EnvironmentName = name });

            //if (_context.Environments.FirstOrDefault(e => e.EnvironmentName == name) != null)
            //{
            //    return true;
            //}

            //return false;

            var state = environment.Environment_Id == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(environment).State = state;
            _context.SaveChanges();
            return environment;
        }

        public Models.Environment ConsultEnvironment(int id)
        {
            return _context.Environments.Find(id);
        }

        public List<Models.Environment> ConsultAllEnvironments()
        {
            return _context.Environments.Select(a => a).ToList();
        }
    }
}
