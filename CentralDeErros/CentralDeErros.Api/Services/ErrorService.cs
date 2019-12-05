using CentralDeErros.Api.Interfaces;
using CentralDeErros.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErros.Api.Services
{
    public class ErrorService : IError
    {
        private ErrorDbContext _context;

        public ErrorService(ErrorDbContext context)
        {
            this._context = context;
        }

        public Error RegisterOrUpdateError(Error error)
        {
            if (_context.Environments.Any(e => e.EnvironmentId == error.EnvironmentId) &&
                _context.Levels.Any(l => l.LevelId == error.LevelId))
            {
                var state = error.ErrorId == 0 ? EntityState.Added : EntityState.Modified;
                _context.Entry(error).State = state;
                _context.SaveChanges();
            }           
            return error;
        }

        public Error ConsultError(int id)
        {
            return _context.Errors.Find(id);
        }

        public List<Error> ConsultAllErrors()
        {
            return _context.Errors.Select(e => e).ToList();
        }

        public bool ErrorExists(int id)
        {
            return _context.Errors.Any(e => e.ErrorId == id);
        }
    }
}
