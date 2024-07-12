using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Repositories
{
    public interface IBookingServiceRepository
    {
        BookingServiceModel GetById(int id);
        IEnumerable<BookingServiceModel> GetAll();
        void Add(BookingServiceModel services);
        void Update(BookingServiceModel services);
        void Delete(BookingServiceModel services);
        void Save();
    }
}
