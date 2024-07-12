using KarapinhaDTO.Category;
using KarapinhaDTO.ProfessionalTime;
using KarapinhaDTO.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Professional
{
    public class ProfessionalDto
    {
        public int ProfessionalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhotoUrl { get; set; }
        public string IdCard { get; set; }
        public int PhoneNumber { get; set; }
        public CategoryDto Category { get; set; }
        public ICollection<TimeDto> Times { get; set; }

        public ProfessionalDto()
        {
            Times = new HashSet<TimeDto>();
        }

    }
}
