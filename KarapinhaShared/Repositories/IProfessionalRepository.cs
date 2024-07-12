using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Repositories
{
    public interface IProfessionalRepository
    {
        ProfessionalModel GetById(int id);
        IEnumerable<ProfessionalModel> GetAll();
        IEnumerable<ProfessionalModel> GetByCategory(int categoryId);
        IEnumerable<ProfessionalModel> GetByService(int serviceId);
        IEnumerable<ProfessionalModel> GetTop5Professionals();
        int GetCountBooking(int id);
        void Add(ProfessionalModel professional);
        void Update(ProfessionalModel professional);
        void Delete(ProfessionalModel professional);
        void Save();
    }
}
