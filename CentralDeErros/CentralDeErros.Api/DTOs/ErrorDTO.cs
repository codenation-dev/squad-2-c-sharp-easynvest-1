using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.DTOs
{
    public class ErrorDTO
    {
        public int Id { get; set; }

        [Required]
        public int EnvironmentId { get; set; }

        [Required]
        public int LevelId { get; set; }

        [Required]
        public int SituationId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
