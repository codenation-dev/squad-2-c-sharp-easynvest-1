using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.DTOs
{
    public class ErrorDTO
    {
        public int Id { get; set; }

        [Required]
        public int Ambiente_Id { get; set; }

        [Required]
        public int Level_Id { get; set; }

        [Required]
        public int Situacao_Id { get; set; }

        [Required]
        public string Titulo { get; set; }
    }
}
