using KarapinhaDTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Service
{
    public class ServiceDto
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int EstimatedTime { get; set; }
        public string Status { get; set; }
        public CategoryDto Category { get; set; }
    }
}
