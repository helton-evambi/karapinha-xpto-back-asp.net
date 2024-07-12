using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Time
{
    public class TimeCreateDto
    {
        [Required]
        public int Hour { get; set; }

        [Required]
        public int Minute { get; set; }
    }
}