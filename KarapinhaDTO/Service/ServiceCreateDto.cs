using KarapinhaDTO.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Service
{
    public class ServiceCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int EstimatedTime { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
