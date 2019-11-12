using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Models
{
    [Table("ocorrenciaErro")]
    public class OcorrenciaErro
    {
        [Column("id")]
        [Key]
        public int Ocorrencia_Id { get; set; }

        //[Column("erro_id"), Required]
        //public int Erro_Id { get; set; }
        //[ForeignKey("ErroId"), Required]
        //public Error Error { get; set; }// referencia 

        [Column("origem")]
        [StringLength(200)]
        [Required]
        public string Origem { get; set; }

        [Column("detalhes")]
        [StringLength(2000)]
        [Required]
        public string Detalhes { get; set; }

        [Column("data_hora")]
        [Required]
        public DateTime Data_Hora { get; set; }

        //[Column("nome_user")]
        //[StringLength(200)]
        //[Required]
        //public string Nome_User{ get; set; }

        [Column("user_id"), Required]
        public int User_Id { get; set; }
        [ForeignKey("UserId"), Required]
        public User User { get; set; }// referencia 

       // public ICollection<Error> Errors{ get; set; }//uma ocorrência pode ter varios erros
    }
}
