using KarapinhaDTO.Professional;
using KarapinhaDTO.Service;
using KarapinhaDTO.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.BookingService
{
    public class BookingServiceDto
    {
        public ServiceDto Service { get; set; }
        public ProfessionalDto Professional { get; set; }
        public TimeDto Time { get; set; }
        public DateTime Date { get; set; }
    }
}