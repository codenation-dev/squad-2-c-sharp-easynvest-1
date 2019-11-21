using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.DTOs
{
    public class LevelDTO
    {
        public int Level_Id { get; set; }

        [Required]
        public string Nome_Level { get; set; }

    }
}
