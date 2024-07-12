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
    public class TimeRepository : ITimeRepository
    {
        private readonly AppDbContext context;
        public TimeRepository()
        {
            context = new AppDbContext();
        }

        public TimeModel GetById(int id)
        {
            return context.Times.Find(id);
        }

        public IEnumerable<TimeModel> GetAll()
        {
            return context.Times;
        }

        public void Add(TimeModel time)
        {
            context.Times.Add(time);
        }

        public void Delete(TimeModel time)
        {
            if (context.Entry(time).State == EntityState.Detached)
            {
                context.Times.Attach(time);
            }
            context.Times.Remove(time);
        }

        public void Update(TimeModel time)
        {
            context.Entry(time).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}
