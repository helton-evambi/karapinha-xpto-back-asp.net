using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaModel
{
    [Table("BookingServices")]
    public class BookingServiceModel
    {
        [Key, Column(Order = 0)]
        public int BookingId { get; set; }

        [Key, Column(Order = 1)]
        public int ServiceId { get; set; }

        [Key, Column(Order = 2)]
        public int ProfessionalId { get; set; }

        [Key, Column(Order = 3)]
        public int TimeId { get; set; }
        
        public DateTime Date {  get; set; }

        [ForeignKey("BookingId")]
        public virtual BookingModel Booking { get; set; }

        [ForeignKey("ServiceId")]
        public virtual ServiceModel Service { get; set; }

        [ForeignKey("ProfessionalId")]
        public virtual ProfessionalModel Professional { get; set; }

        [ForeignKey("TimeId")]
        public virtual TimeModel Time { get; set; }

    }
}
