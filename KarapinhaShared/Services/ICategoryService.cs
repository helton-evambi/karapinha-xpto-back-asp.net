using KarapinhaDTO.Booking;
using KarapinhaDTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Services
{
    public interface ICategoryService
    {
        CategoryDto GetById(int id);
        IEnumerable<CategoryDto> GetAll();
        void CreateCategory(CategoryCreateDto categoryCreateDto);
        void UpdateCategory(int id, CategoryCreateDto categoryCreateDto);
        void UpdateCategoryStatus(int id, string status);
        void DeleteCategory(int id);
    }
}
