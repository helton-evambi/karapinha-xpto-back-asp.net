using KarapinhaDTO.Booking;
using KarapinhaDTO.Professional;
using KarapinhaDTO.ProfessionalTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Services
{
    public interface IProfessionalTimeService
    {
        ProfessionalTimeDto GetById(int id);
        IEnumerable<ProfessionalTimeDto> GetAll();
        void CreateBooking(ProfessionalTimeCreateDto professionalTimeCreateDto);
        void UpdateBooking(ProfessionalTimeCreateDto professionalTimeCreateDto);
        void DeleteBooking(int id);
    }
}
