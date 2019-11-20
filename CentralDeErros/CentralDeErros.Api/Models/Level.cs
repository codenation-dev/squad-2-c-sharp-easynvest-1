using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Models
{
    [Table ("level")]
    public class Level
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Level_Id { get; set; }

        [Column("level")]
        [StringLength(30)]
        [Required]
        public string Nome_Level { get; set; }

        public ICollection<Error> Errors { get; set; }//um level pode ter varios erros
    }
}
