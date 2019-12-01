using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.DTOs
{
    public class ErrorOccurrenceDTO
    {
        public int ErrorOccurrenceId { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ErrorId { get; set; }

    }
}
