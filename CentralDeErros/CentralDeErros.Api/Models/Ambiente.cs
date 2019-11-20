using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Models
{
    [Table("ambiente")]
    public class Ambiente
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ambiente_Id { get; set; }

        [Column("ambiente")]
        [StringLength(30)]
        [Required]
        public string Nome_Ambiente { get; set; }

        public ICollection<Error> Errors { get; set; }//um ambiente pode ter varios erros


    }
}
