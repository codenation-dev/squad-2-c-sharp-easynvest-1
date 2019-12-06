﻿using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface IErrorOccurrence
    {
        ErrorOccurrence RegisterOrUpdateErrorOccurrence(ErrorOccurrence errorOccurrence);

        ErrorOccurrence ConsultErrorOccurrenceById(int errorOccurrenceId);

        List<ErrorOccurrence> ListOccurencesByLevel(int level);

        List<ErrorOccurrence> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);

        bool ErrorOccurrenceExists(int id);

        ErrorOccurrence FileErrorOccurrence(ErrorOccurrence errorOccurrence);

        ErrorOccurrence DeleteErrorOccurrence(ErrorOccurrence errorOccurrence);
    }
}
