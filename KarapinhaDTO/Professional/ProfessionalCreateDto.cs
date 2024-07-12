using KarapinhaDTO.ProfessionalTime;
using KarapinhaDTO.Time;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Professional
{
    public class ProfessionalCreateDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public string PhotoUrl { get; set; }

        [Required]
        public string IdCard { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public int CategoryId {  get; set; }

        [Required]
        public ICollection<ProfessionalTimeCreateDto> Times { get; set; }

        public ProfessionalCreateDto()
        {
            Times = new HashSet<ProfessionalTimeCreateDto>();
        }
    }
}
