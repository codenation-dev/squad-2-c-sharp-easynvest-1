using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Models
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        [Key]
        public int User_Id { get; set; }

        [Column("name")]
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [Column("email")]
        [StringLength(200)]
        [Required]
        public string Email { get; set; }

        [Column("password")]
        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        [Column("token")]
        [MaxLength(40)]
        [Required]
        public string Token { get; set; }

        public ICollection<OcorrenciaErro> OcorrenciaErros { get; set; }//um usuario pode ter varios erros

    }
}
