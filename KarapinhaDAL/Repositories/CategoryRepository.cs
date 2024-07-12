using KarapinhaModel;
using KarapinhaShared.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository()
        {
            context = new AppDbContext();
        }

        public CategoryModel GetById(int id)
        {
            return context.Categories.Find(id);
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            return context.Categories;
        }

        public void Add(CategoryModel category)
        {
           context.Categories.Add(category);
        }

        public void Update(CategoryModel category)
        {
            var updateCategory = context.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            updateCategory = category;
            context.Entry(updateCategory).State = EntityState.Modified;
            
        }

        public void UpdateSatus(CategoryModel category)
        {
            context.Categories.Attach(category);
            context.Entry(category).Property(c => c.Status).IsModified = true;
        }

        public void Delete(CategoryModel category)
        {
            if(context.Entry(category).State == EntityState.Detached)
            {
                context.Categories.Attach(category);
            }
            context.Categories.Remove(category);
        }
        
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
