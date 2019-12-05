using CentralDeErros.Api.Interfaces;
using CentralDeErros.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    public class ErrorOccurrenceService : IErrorOccurrence
    {

        private ErrorDbContext _context;

        public ErrorOccurrenceService (ErrorDbContext context)
        {
            _context = context;
        }

        public ErrorOccurrence RegisterOrUpdateErrorOccurrence(ErrorOccurrence errorOccurrence)
        {
            if (_context.Users.Any(u => u.UserId == errorOccurrence.UserId) &&
                 _context.Errors.Any(e => e.ErrorId == errorOccurrence.ErrorId) &&
                 _context.Situations.Any(s => s.SituationId == errorOccurrence.SituationId))
            {
                var state = errorOccurrence.ErrorOccurrenceId == 0 ? EntityState.Added : EntityState.Modified;
                _context.Entry(errorOccurrence).State = state;
                _context.SaveChanges();
            }

            return errorOccurrence;
        }

        public List<ErrorOccurrence> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado)
        {
            // dado vem do frontEnd

            // Campo ordenação
            // 1 - Level
            // 2 - Frequência

            // Campo buscado
            // 1 - Level
            // 2 - Descrição
            // 3 - Origem

            //TODO

            //Func<OcorrenciaErro, Object> orderByFunc = null;
            //if (sortOrder == SortOrder.SortByName)
            //    orderByFunc = item => item.Error.Level;
            //else if (sortOrder == SortOrder.SortByRank)
            //    orderByFunc = item => item.Rank;

            //string ordenacao = null;

            //if (campoOrdenacao == 1)
            //{
            //    ordenacao = "Error.Level";

            //} 
            //else if (campoOrdenacao == 2)
            //{
            //    ordenacao = "Error.Frequencia";
            //}

            return _context.ErrorOccurrences.Where(o => o.Error.EnvironmentId == ambiente).ToList();
        }

        public List<ErrorOccurrence> ListOccurencesByLevel(int level)
        {
            return _context.ErrorOccurrences.Where(o => o.Error.LevelId == level).ToList();
        }

        public bool ErrorOccurrenceExists(int id)
        {
            return _context.ErrorOccurrences.Any(e => e.ErrorOccurrenceId == id);
        }
    }
}
