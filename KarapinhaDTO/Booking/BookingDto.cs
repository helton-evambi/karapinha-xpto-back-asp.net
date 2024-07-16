using KarapinhaDTO.BookingService;
using KarapinhaDTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Booking
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime ActivationDate { get; set; }
        public UserDto User { get; set; }
        public ICollection<BookingServiceDto> Services { get; set; }

        public BookingDto()
        {
            Services = new HashSet<BookingServiceDto>();
        }
    }
}
