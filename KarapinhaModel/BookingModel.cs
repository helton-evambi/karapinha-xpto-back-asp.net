using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaModel
{
    [Table("Bookings")]
    public class BookingModel
    {
        [Key]
        public int BookingId { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }
        public virtual ICollection<BookingServiceModel> Services { get; set; }   
        public BookingModel()
        {
            Services = new HashSet<BookingServiceModel>();
        }
    }
}
