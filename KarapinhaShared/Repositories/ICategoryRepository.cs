using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Repositories
{
    public interface ICategoryRepository
    {
        CategoryModel GetById(int id);
        IEnumerable<CategoryModel> GetAll();
        void Add(CategoryModel category);
        void Update(CategoryModel category);
        void UpdateSatus(CategoryModel category);
        void Delete(CategoryModel category);
        void Save();
    }
}
