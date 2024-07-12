using KarapinhaDTO.Professional;
using KarapinhaDTO.Service;
using KarapinhaDTO.Time;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.BookingService
{
    public class BookingServiceCreateDto
    {
        [Required]
        public ServiceDto Service { get; set; }

        [Required]
        public ProfessionalDto Professional { get; set; }

        [Required]
        public TimeDto Time { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
