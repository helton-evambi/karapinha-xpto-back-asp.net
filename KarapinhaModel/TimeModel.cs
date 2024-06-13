using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaModel
{
    [Table("Times")]
    public class TimeModel
    {
        [Key]
        public int TimeId { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        public ICollection<BookingServiceModel> Bookings { get; set; }
        public ICollection<ProfessionalTimeModel> Professionals { get; set; }

        public TimeModel()
        {
            Bookings = new HashSet<BookingServiceModel>();
            Professionals = new HashSet<ProfessionalTimeModel>();
        }

    }
}
