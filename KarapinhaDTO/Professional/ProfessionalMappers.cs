using KarapinhaDTO.Category;
using KarapinhaDTO.ProfessionalTime;
using KarapinhaDTO.Time;
using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Professional
{
    public static class ProfessionalMappers
    {
        public static ProfessionalDto ToProfessioanlDto(ProfessionalModel professional)
        {
            if (professional == null)
            {
                return null;
            }
            return new ProfessionalDto
            {
                ProfessionalId = professional.ProfessionalId,
                FirstName = professional.FirstName,
                LastName = professional.LastName,
                EmailAddress = professional.EmailAddress,
                PhoneNumber = professional.PhoneNumber,
                PhotoUrl = professional.PhotoUrl,
                IdCard = professional.IdCard,
                Category = CategoryMappers.ToCategoryDto(professional.Category),
                Times = professional.Times.Select(x => TimeMappers.ToTimeDto(x.Time)).ToList(),
            };
        }

        public static ProfessionalModel CreateToProfessional(ProfessionalCreateDto professional)
        {
            return new ProfessionalModel
            {
                FirstName = professional.FirstName,
                LastName = professional.LastName,
                EmailAddress = professional.EmailAddress,
                PhotoUrl = professional.PhotoUrl,
                IdCard = professional.IdCard,
                PhoneNumber = professional.PhoneNumber,
                CategoryId = professional.CategoryId,
                Times = professional.Times.Select(x => ProfessionalTimeMappers.CreateToProfessionalTime(x)).ToList(),
            };
        }
    }
}