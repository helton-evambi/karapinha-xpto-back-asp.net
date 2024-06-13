using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaModel
{
    [Table("Professionals")]
    public class ProfessionalModel
    {
        [Key]
        public int ProfessionalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhotoUrl {  get; set; }
        public string IdCard {  get; set; }
        public int PhoneNumber { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryModel Category { get; set; }

        public virtual ICollection<ProfessionalTimeModel> Times { get; set; }
        public virtual ICollection<BookingServiceModel> Bookings { get; set; }

        public ProfessionalModel()
        {
            Times = new HashSet<ProfessionalTimeModel>();
            Bookings= new HashSet<BookingServiceModel>();
        }

    }
}