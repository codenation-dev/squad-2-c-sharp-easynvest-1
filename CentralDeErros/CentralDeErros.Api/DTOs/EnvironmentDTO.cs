using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.DTOs
{
    public class EnvironmentDTO
    {
        public int EnvironmentId { get; set; }

        [Required]
        public string EnvironmentName { get; set; }
    }
}
