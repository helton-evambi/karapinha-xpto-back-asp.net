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
    public class ProfessionalRepository : IProfessionalRepository
    {
        private readonly AppDbContext context;

        public ProfessionalRepository()
        {
            context = new AppDbContext();
        }

        public ProfessionalModel GetById(int id)
        {
            return context.Professionals.Include(x => x.Category)
                                        .Include(x => x.Times.Select(y => y.Time))
                                        .FirstOrDefault(x => x.ProfessionalId == id);
        }

        public IEnumerable<ProfessionalModel> GetAll()
        {
            return context.Professionals.Include(x => x.Category)
                                        .Include(x => x.Times.Select(y => y.Time));
                                        
        }

        public IEnumerable<ProfessionalModel> GetByCategory(int categoryId)
        {
            return context.Professionals.Include(x => x.Category)
                                        .Include(x => x.Times.Select(y => y.Time))
                                        .Where(x => x.CategoryId == categoryId);
        }

        public IEnumerable<ProfessionalModel> GetByService(int serviceId)
        {
            return context.Professionals.Include(x => x.Category)
                                        .Include(x => x.Times.Select(y => y.Time))
                                        .Where(x => x.Category.Services.Any(y => y.ServiceId == serviceId));
        }

        public IEnumerable<ProfessionalModel> GetTop5Professionals()
        {
            return context.Professionals.Include(x => x.Category)
                                        .Include(x => x.Times.Select(y => y.Time))
                                        .OrderByDescending(x => x.Bookings.Count())
                                        .Take(5);
        }

        public int GetCountBooking(int id)
        {
            var professional = context.Professionals
                              .Include(x => x.Bookings)
                              .SingleOrDefault(x => x.ProfessionalId == id);
            return professional?.Bookings.Count ?? 0;
        }

        public void Add(ProfessionalModel professional)
        {
            context.Professionals.Add(professional);
        }

        public void Delete(ProfessionalModel professional)
        {
            if (context.Entry(professional).State == EntityState.Detached)
            {
                context.Professionals.Attach(professional);
            }
            context.Professionals.Remove(professional);
        }

        public void Update(ProfessionalModel professional)
        {
            context.Entry(professional).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}
