using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaModel
{
    [Table("Services")]
    public class ServiceModel
    {
        [Key]
        public int ServiceId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int EstimatedTime { get; set; }
        public string Status { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryModel Category { get; set; }

        public ICollection<BookingServiceModel> Bookings { get; set; }

        public ServiceModel()
        {
            Bookings = new HashSet<BookingServiceModel>();
        }
    }
}