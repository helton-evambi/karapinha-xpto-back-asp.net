using KarapinhaDTO.BookingService;
using KarapinhaDTO.User;
using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Booking
{
    public static class BookingMappers
    {
        public static BookingDto ToBookingDto(BookingModel booking)
        {
            if (booking == null)
            {
                return null;
            }

            return new BookingDto
            {
                BookingId = booking.BookingId,
                Price = booking.Price,
                Status = booking.Status,
                User = UserMappers.ToUserDto(booking.User),
                Services = booking.Services.Select(x => BookingServiceMappers.ToBookingServiceDto(x)).ToList(),

            };
        }

        public static BookingModel CreateToBooking(BookingCreateDto booking)
        {
            return new BookingModel
            {
                Price = booking.Price,
                UserId = booking.UserId,
                Status = "pending",
                Services = booking.Services.Select(x => BookingServiceMappers.CreateToBookingService(x)).ToList()
            };
        }

        /*public static void UpdateUser(BookingModel existingBooking, BookingCreateDto dto)
        {
            existingBooking.UserId = dto.UserId;
            existingBooking.Price = dto.Price;
            existingBooking.Services = dto.Services.Select(x =>
            {
                x.Professional = x.
            })
        }*/
    }
}
