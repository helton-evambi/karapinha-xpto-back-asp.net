using KarapinhaDTO.Booking;
using KarapinhaDTO.Professional;
using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Services
{
    public interface IProfessionalService
    {
        ProfessionalDto GetById(int id);
        IEnumerable<ProfessionalDto> GetAll();
        IEnumerable<ProfessionalDto> GetByCategory(int categoryId);
        IEnumerable<ProfessionalDto> GetByService(int serviceId);
        IEnumerable<ProfessionalDto> GetTop5Professionals();
        int GetCountBooking(int id);
        void CreateProfessional(ProfessionalCreateDto professionalCreateDto);
        void UpdateProfessional(ProfessionalCreateDto professionalCreateDto);
        void DeleteProfessional(int id);
    }
}
