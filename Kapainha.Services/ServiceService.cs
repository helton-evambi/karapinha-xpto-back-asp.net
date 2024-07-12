using KarapinhaDAL.Repositories;
using KarapinhaDTO.Professional;
using KarapinhaDTO.Service;
using KarapinhaShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapainha.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ServiceRepository _repository;

        public ServiceService()
        {
            _repository = new ServiceRepository();
        }

        public ServiceDto GetById(int id)
        {
            var service = _repository.GetById(id);
            return ServiceMappers.ToServiceDto(service);
        }

        public IEnumerable<ServiceDto> GetAll()
        {
            var services = _repository.GetAll();
            return services.Select(x => ServiceMappers.ToServiceDto(x));
        }

        public IEnumerable<ServiceDto> GetByCategory(int categoryId)
        {
            var services = _repository.GetByCategory(categoryId);
            return services.Select(x => ServiceMappers.ToServiceDto(x));
        }

        public void CreateService(ServiceCreateDto serviceCreateDto)
        {
            var service = ServiceMappers.CreateToService(serviceCreateDto);
            _repository.Add(service);
            _repository.Save();
        }

        public void DeleteService(int id)
        {
            var service = _repository.GetById(id);
            if (service != null)
            {
                _repository.Delete(service);
                _repository.Save();
            }
        }

        public void UpdateService(ServiceCreateDto serviceCreateDto)
        {
            var service = ServiceMappers.CreateToService(serviceCreateDto);
            _repository.Update(service);
            _repository.Save();
        }

        public void UpdateServiceStatus(int id, string status)
        {
            var existingService = _repository.GetById(id) ?? throw new KeyNotFoundException("User not found");
            existingService.Status = status;

            _repository.UpdateStatus(existingService);
            _repository.Save();
        }

        public ServiceDto GetMostRequestedService()
        {
            var service = _repository.GetMostRequestedService();
            return ServiceMappers.ToServiceDto(service);
        }

        public ServiceDto GetLeastRequestedService()
        {
            var service = _repository.GetLeastRequestedService();
            return ServiceMappers.ToServiceDto(service);
        }

    }
}
