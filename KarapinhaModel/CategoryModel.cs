using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaModel
{
    [Table("Categories")]
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagem { get; set; }
        public string Status { get; set; }
        public virtual ICollection<ServiceModel> Services { get; set; }
        public virtual ICollection<ProfessionalModel> Professionals { get; set; }

        public CategoryModel()
        {
            Services = new HashSet<ServiceModel>();
            Professionals = new HashSet<ProfessionalModel>();
        }
    }
}
