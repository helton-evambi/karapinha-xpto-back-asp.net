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
    public class BookingServiceRepository : IBookingServiceRepository
    {
        private readonly AppDbContext context;

        public BookingServiceRepository()
        {
            context = new AppDbContext();
        }
        public BookingServiceModel GetById(int id)
        {
            return context.BookingServices.Find(id);
        }

        public IEnumerable<BookingServiceModel> GetAll()
        {
            return context.BookingServices;
        }

        public void Add(BookingServiceModel services)
        {
            context.BookingServices.Add(services);
        }

        public void Update(BookingServiceModel services)
        {
            context.Entry(services).State = EntityState.Modified;
        }

        public void Delete(BookingServiceModel services)
        {
            if (context.Entry(services).State == EntityState.Detached)
            {
                context.BookingServices.Attach(services);
            }
            context.BookingServices.Remove(services);
        }        

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
