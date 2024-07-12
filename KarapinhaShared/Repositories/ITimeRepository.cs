using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Repositories
{
    public interface ITimeRepository
    {
        TimeModel GetById(int id);
        IEnumerable<TimeModel> GetAll();
        void Add(TimeModel time);
        void Update(TimeModel time);
        void Delete(TimeModel time);
        void Save();
    }
}
