﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.DTOs
{
    public class EnvironmentDTO
    {
        public int Environment_Id { get; set; }

        public string EnvironmentName { get; set; }
    }
}
