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
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext context;

        public ServiceRepository()
        {
            context = new AppDbContext();
        }

        public ServiceModel GetById(int id)
        {
            return context.Services.Include(x => x.Category).FirstOrDefault(x => x.ServiceId == id);
        }

        public IEnumerable<ServiceModel> GetAll()
        {
            return context.Services.Include(x => x.Category);
        }

        public IEnumerable<ServiceModel> GetByCategory(int categoryId)
        {
            return context.Services.Include(x => x.Category)
                                   .Where(x => x.CategoryId == categoryId);
        }

        public void Add(ServiceModel service)
        {
            context.Services.Add(service);
        }

        public void Delete(ServiceModel service)
        {
            if (context.Entry(service).State == EntityState.Detached)
            {
                context.Services.Attach(service);
            }
            context.Services.Remove(service);
        }

        public void Update(ServiceModel service)
        {
            context.Entry(service).State = EntityState.Modified;
        }
        public void UpdateStatus(ServiceModel service)
        {
            context.Services.Attach(service);
            context.Entry(service).Property(s => s.Status).IsModified = true;
        }

        public ServiceModel GetMostRequestedService()
        {
            return context.Services.Include(x => x.Category)
                                         .OrderByDescending(x => x.Bookings.Count())
                                         .FirstOrDefault();
        }

        public ServiceModel GetLeastRequestedService()
        {
            return context.Services.Include(x => x.Category)
                                         .OrderBy(x => x.Bookings.Count())
                                         .FirstOrDefault();
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
