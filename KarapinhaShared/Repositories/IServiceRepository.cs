using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Repositories
{
    public interface IServiceRepository
    {
        ServiceModel GetById(int id);
        IEnumerable<ServiceModel> GetAll();
        IEnumerable<ServiceModel> GetByCategory(int categoryId);
        ServiceModel GetMostRequestedService();
        ServiceModel GetLeastRequestedService();
        void Add(ServiceModel service);
        void Update(ServiceModel service);
        void UpdateStatus(ServiceModel service);
        void Delete(ServiceModel service);
        void Save();
    }
}
