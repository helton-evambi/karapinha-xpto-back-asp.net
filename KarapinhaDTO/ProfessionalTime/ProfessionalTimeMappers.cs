using KarapinhaDTO.Time;
using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.ProfessionalTime
{
    public static class ProfessionalTimeMappers
    {
        public static ProfessionalTimeDto ToProfessionalTimeDto (ProfessionalTimeModel times)
        {
            if (times == null)
            {
                return null;
            }
            return new ProfessionalTimeDto
            {
                Time = TimeMappers.ToTimeDto(times.Time),
            };
        }

        public static ProfessionalTimeModel CreateToProfessionalTime (ProfessionalTimeCreateDto times)
        {
            return new ProfessionalTimeModel
            {
                TimeId = times.TimeId,
            };
        }
    }
}
