using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Models
{
    public class Situacao
    {
        [Column("id")]
        [Key]
        public int Situacao_Id { get; set; }

        [Column("situacao")]
        [StringLength(30)]
        [Required]
        public string Nome_Situacao { get; set; }

        public ICollection<Error> Errors { get; set; }//uma situação pode ter varios erros
    }
}
