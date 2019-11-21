using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.DTOs
{
    public class OcorrenciaErroDTO
    {
        public int Ocorrencia_Id { get; set; }

        [Required]
        public string Origem { get; set; }

        [Required]
        public string Detalhes { get; set; }

        [Required]
        public DateTime Data_Hora { get; set; }

        [Required]
        public int User_Id { get; set; }

        [Required]
        public int Erro_Id { get; set; }

    }
}
