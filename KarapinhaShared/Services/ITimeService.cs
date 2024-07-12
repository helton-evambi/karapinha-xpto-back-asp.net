using KarapinhaDTO.Booking;
using KarapinhaDTO.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Services
{
    public interface ITimeService
    {
        TimeDto GetById(int id);
        IEnumerable<TimeDto> GetAll();
        void CreateTime(TimeCreateDto bookingCreateDto);
        void UpdateTime(TimeCreateDto bookingCreateDto);
        void DeleteTime(int id);
    }
}
