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
        public int Id { get; set; }

        [Column("ambiente_id"), Required]
        public int Ambiente_Id { get; set; }
        [ForeignKey("AmbienteId"), Required]
        public Ambiente Ambiente { get; set; }// referencia 

        [Column("level_id"), Required]
        public int Level_Id { get; set; }
        [ForeignKey("LevelId"), Required]
        public Level Level { get; set; }// referencia 

        [Column("situacao_id"), Required]
        public int Situacao_Id { get; set; }
        [ForeignKey("SituacaoId"), Required]
        public Situacao Situacao { get; set; }// referencia 


        [Column("ocorrencia_id"), Required]
        public int Ocorrencia_Id { get; set; }
        [ForeignKey("OcorrenciaId"), Required]
        public OcorrenciaErro OcorrenciaErros { get; set; }// referencia 

        [Column("titulo")]
        [StringLength(200)]
        [Required]
        public string Titulo { get; set; }

    }
}
