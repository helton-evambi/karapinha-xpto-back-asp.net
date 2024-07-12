using KarapinhaModel;
using KarapinhaShared.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDAL.Repositories
{
    public class ProfessionalTimeRepository : IProfessionalTimeRepository
    {
        private readonly AppDbContext context;

        public ProfessionalTimeRepository()
        {
            context = new AppDbContext();
        }
        public ProfessionalTimeModel GetById(int id)
        {
            return context.ProfessionalTimes.Find(id);
        }

        public IEnumerable<ProfessionalTimeModel> GetAll()
        {
            return context.ProfessionalTimes;
        }

        public void Add(ProfessionalTimeModel times)
        {
            context.ProfessionalTimes.Add(times);
        }

        public void Delete(ProfessionalTimeModel times)
        {
            if (context.Entry(times).State == EntityState.Detached)
            {
                context.ProfessionalTimes.Attach(times);
            }
            context.ProfessionalTimes.Remove(times);
        }

        public void Update(ProfessionalTimeModel times)
        {
            context.Entry(times).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
