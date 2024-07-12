using KarapinhaDTO.Booking;
using KarapinhaDTO.Service;
using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Services
{
    public interface IServiceService
    {
        ServiceDto GetById(int id);
        IEnumerable<ServiceDto> GetAll();
        IEnumerable<ServiceDto> GetByCategory (int categoryId);
        ServiceDto GetMostRequestedService();
        ServiceDto GetLeastRequestedService();
        void CreateService(ServiceCreateDto serviceCreateDto);
        void UpdateService(ServiceCreateDto serviceCreateDto);
        void UpdateServiceStatus(int id, string status);
        void DeleteService(int id);
    }
}
