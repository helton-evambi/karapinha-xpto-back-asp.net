using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Repositories
{
    public interface IProfessionalTimeRepository
    {
        ProfessionalTimeModel GetById(int id);
        IEnumerable<ProfessionalTimeModel> GetAll();
        void Add(ProfessionalTimeModel times);
        void Update(ProfessionalTimeModel times);
        void Delete(ProfessionalTimeModel times);
        void Save();
    }
}
