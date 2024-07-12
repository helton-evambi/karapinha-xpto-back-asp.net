using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Category
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagem { get; set; }
    }
}
