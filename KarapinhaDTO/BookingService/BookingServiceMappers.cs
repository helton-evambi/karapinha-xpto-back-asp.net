using KarapinhaDTO.Professional;
using KarapinhaDTO.Service;
using KarapinhaDTO.Time;
using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.BookingService
{
    public static class BookingServiceMappers
    {
        public static BookingServiceDto ToBookingServiceDto (BookingServiceModel bookingService)
        {
            if (bookingService == null)
            {
                return null;
            }
            return new BookingServiceDto
            {
                Date = bookingService.Date,
                Service = ServiceMappers.ToServiceDto(bookingService.Service),
                Professional = ProfessionalMappers.ToProfessioanlDto(bookingService.Professional),
                Time = TimeMappers.ToTimeDto(bookingService.Time),  
            };
        }

        public static BookingServiceModel CreateToBookingService (BookingServiceCreateDto services)
        {
            return new BookingServiceModel
            {
                ServiceId = services.Service.ServiceId,
                ProfessionalId = services.Professional.ProfessionalId,
                TimeId = services.Time.TimeId,
                Date = services.Date,
            };
        }
    }
}
