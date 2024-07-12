using KarapinhaDTO.Professional;
using KarapinhaDTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagem { get; set; }
        public string Status { get; set; }

    }
}
