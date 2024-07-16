using KarapinhaDAL.Repositories;
using KarapinhaDTO.Category;
using KarapinhaModel;
using KarapinhaShared.Repositories;
using KarapinhaShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapainha.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _repository;

        public CategoryService()
        {
            _repository = new CategoryRepository();
        }

        public CategoryDto GetById(int id)
        {
            var category = _repository.GetById(id);
            return CategoryMappers.ToCategoryDto(category);
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = _repository.GetAll();
            return categories.Select(x => CategoryMappers.ToCategoryDto(x));
        }

        public void CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            var category = CategoryMappers.CreateToCategory(categoryCreateDto);
            _repository.Add(category);
            _repository.Save();

        }
        public void UpdateCategory(int id, CategoryCreateDto categoryCreateDto)
        {
            var category = CategoryMappers.CreateToCategory(categoryCreateDto);
            category.CategoryId = id;
            _repository.Update(category);
            _repository.Save();
        }

        public void UpdateCategoryStatus(int id, string status)
        {
            var existingCategory = _repository.GetById(id) ?? throw new KeyNotFoundException("User not found");
            existingCategory.Status = status;

            _repository.UpdateSatus(existingCategory);
            _repository.Save();
        }

        public void DeleteCategory(int id)
        {
            var category = _repository.GetById(id);
            try
            {
                if (category != null)
                {
                    _repository.Delete(category);
                    _repository.Save();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
