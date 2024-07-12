using KarapinhaDTO.Category;
using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Service
{
    public static class ServiceMappers
    {
        public static ServiceDto ToServiceDto (ServiceModel service)
        {
           if (service == null)
            {
                return null;
            }
            return new ServiceDto
            {
                ServiceId = service.ServiceId,
                Name = service.Name,
                Description = service.Description,
                Image = service.Image,
                EstimatedTime = service.EstimatedTime,
                Price = service.Price,
                Status = service.Status,
                Category = CategoryMappers.ToCategoryDto(service.Category),
            };
        }

        public static ServiceModel CreateToService (ServiceCreateDto service)
        {
            return new ServiceModel
            {
                Name = service.Name,
                Description = service.Description,
                Image = service.Image,
                EstimatedTime = service.EstimatedTime,
                Price = service.Price,
                CategoryId = service.CategoryId,
                Status = "active",
            };
        }
    }
}
