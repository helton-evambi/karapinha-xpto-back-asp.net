using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Repositories
{
    public interface IBookingRepository
    {
        BookingModel GetById(int id);
        IEnumerable<BookingModel> GetAll();
        IEnumerable<BookingModel> GetByUser(int userId);
        decimal GetRevenueForDay(DateTime day);
        decimal GetRevenueForMonth(int month, int year);
        void Add(BookingModel booking);
        void Update(BookingModel booking);
        void UpdatingSatus(BookingModel booking);
        void Delete(BookingModel booking);
        void Save();
    }
}
