using KarapinhaModel;
using KarapinhaShared.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext context;

        public BookingRepository()
        {
            context = new AppDbContext();
        }

        public BookingModel GetById(int id)
        {
            return context.Bookings
                          .Include(x => x.User)
                          .Include(x => x.Services.Select(y => y.Service))
                          .Include(x => x.Services.Select(y => y.Time))
                          .Include(x => x.Services.Select(y => y.Professional))
                          .FirstOrDefault(x => x.BookingId == id);
        }

        public IEnumerable<BookingModel> GetAll()
        {
            return context.Bookings
                          .Include(x => x.User)   
                          .Include(x => x.Services.Select(y => y.Service))
                          .Include(x => x.Services.Select(y => y.Time))
                          .Include(x => x.Services.Select(y => y.Professional));
        }
        public IEnumerable<BookingModel> GetByUser(int userId)
        {
            return context.Bookings
                          .Include(x => x.User)
                          .Include(x => x.Services.Select(y => y.Service))
                          .Include(x => x.Services.Select(y => y.Time))
                          .Include(x => x.Services.Select(y => y.Professional))
                          .Where(x => x.UserId == userId);
        }

        public void Add(BookingModel booking)
        {
            context.Bookings.Add(booking);
        }

        public void Delete(BookingModel booking)
        {
            if (context.Entry(booking).State == EntityState.Detached)
            {
                context.Bookings.Attach(booking);
            }
            context.Bookings.Remove(booking);
        }

        public void Update(BookingModel booking)
        {
            var existingBooking = context.Bookings
                        .Include(x => x.Services)
                        .FirstOrDefault(x => x.BookingId == booking.BookingId);
            if (existingBooking != null)
            {
                context.Entry(existingBooking).State = EntityState.Detached;
            }
            context.Bookings.Attach(booking);
            context.Entry(booking).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void UpdatingSatus(BookingModel booking)
        {
            context.Bookings.Attach(booking);
            context.Entry(booking).Property(b => b.Status).IsModified = true;
            context.Entry(booking).Property(b => b.ActivationDate).IsModified = true;
        }

        public decimal GetRevenueForDay(DateTime day)
        {
            var truncatedDay = day.Date;

            return context.Bookings
                          .Where(x => DbFunctions.TruncateTime(x.ActivationDate) == truncatedDay && x.Status == "active")
                          .Sum(x => (decimal?)x.Price) ?? 0;
        }


        public decimal GetRevenueForMonth(int month, int year)
        {
            return context.Bookings
                          .Where(x => x.ActivationDate.Month == month && x.ActivationDate.Year == year && x.Status == "active")
                          .Sum(x => (decimal?)x.Price) ?? 0;
        }


        public void Save()
        {
            context.SaveChanges();
        }

       
    }
}
