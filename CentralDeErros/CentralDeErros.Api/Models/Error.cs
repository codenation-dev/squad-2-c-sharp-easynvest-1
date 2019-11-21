using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Models
{
    [Table("error")]
    public class Error
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ambiente_id"), Required]
        public int Ambiente_Id { get; set; }

        [Column("AmbienteId"), Required]
        public Ambiente Ambiente { get; set; }// referencia 

        [ForeignKey("level_id"), Required]
        public int Level_Id { get; set; }

        [Column("LevelId"), Required]
        public Level Level { get; set; }// referencia 

        [ForeignKey("situacao_id"), Required]
        public int Situacao_Id { get; set; }

        [Column("SituacaoId"), Required]
        public Situacao Situacao { get; set; }// referencia 

        //[Column("ocorrencia_id"), Required]
        //public int Ocorrencia_Id { get; set; }

        //[ForeignKey("OcorrenciaId"), Required]
        //public OcorrenciaErro OcorrenciaErros { get; set; }// referencia 

        [Column("titulo")]
        [StringLength(200)]
        [Required]
        public string Titulo { get; set; }
    }
}
