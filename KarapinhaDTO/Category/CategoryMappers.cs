using KarapinhaDTO.Professional;
using KarapinhaDTO.Service;
using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Category
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto (CategoryModel category)
        {
            if (category == null)
            {
                return null;
            }

            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                Imagem = category.Imagem,
                Status = category.Status,
            };
        }

        public static CategoryModel CreateToCategory (CategoryCreateDto category )
        {
            return new CategoryModel
            { 
                Name = category.Name,
                Description = category.Description,
                Imagem = category.Imagem,
                Status = "active",
            };
        }
    }
}
