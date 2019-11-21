using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.DTOs
{
    public class SituacaoDTO
    {
        public int Situacao_Id { get; set; }

        [Required]
        public string Nome_Situacao { get; set; }
    }
}
