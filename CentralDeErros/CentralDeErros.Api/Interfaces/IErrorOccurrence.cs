using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    interface IErrorOccurrence
    {
        ErrorOccurrence RegisterOrUpdateErrorOccurrence(ErrorOccurrence errorOccurrence);

        // retorna a lista (detalhada) de todos os erros de um tipo de level individualmente
        List<ErrorOccurrence> ListOccurencesByLevel(int level);

        // retorna 
        List<ErrorOccurrence> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);

        bool ErrorOccurrenceExists(int id);
    }
}
