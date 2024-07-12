using KarapinhaDTO.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Services
{
    public interface IBookingService
    {
        BookingDto GetById(int id);
        IEnumerable<BookingDto> GetAll();
        IEnumerable<BookingDto> GetByUser(int userId);
        decimal GetRevenueForDay(DateTime day);
        decimal GetRevenueForMonth(int month, int year);
        decimal GetRevenueForYesterday();
        decimal GetRevenueForCurrentMonth();
        decimal GetRevenueForLastMonth();
        void CreateBooking(BookingCreateDto bookingCreateDto);
        void UpdateBooking(int id, BookingCreateDto bookingCreateDto);
        void UpdateBookingStatus(int id, string status);
        void DeleteBooking(int id);
    }
}
