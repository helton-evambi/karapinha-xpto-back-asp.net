using KarapinhaDTO.BookingService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Booking
{
    public class BookingCreateDto
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public ICollection<BookingServiceCreateDto> Services { get; set; }

        public BookingCreateDto()
        {
            Services = new HashSet<BookingServiceCreateDto>();
        }
    }
}
