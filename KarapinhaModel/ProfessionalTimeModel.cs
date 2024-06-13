using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaModel
{
    [Table("ProfessionalTimes")]
    public class ProfessionalTimeModel
    {
        [Key, Column(Order = 0)]
        public int ProfessionalId { get; set; }

        [Key, Column(Order = 1)]
        public int TimeId { get; set; }

        [ForeignKey("ProfessionalId")]
        public virtual ProfessionalModel Professional { get; set; }

        [ForeignKey("TimeId")]
        public virtual TimeModel Time { get; set; }

    }
}
