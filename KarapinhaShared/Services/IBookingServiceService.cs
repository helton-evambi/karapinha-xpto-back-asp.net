using KarapinhaDTO.Booking;
using KarapinhaDTO.BookingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Services
{
    public interface IBookingServiceService
    {
        BookingServiceDto GetById(int id);
        IEnumerable<BookingServiceDto> GetAll();
        void CreateBookingService (BookingServiceCreateDto bookingServiceCreateDto);
        void UpdateBookingService (BookingServiceCreateDto bookingServiceCreateDto);
        void DeleteBookingService (int id);
    }
}
