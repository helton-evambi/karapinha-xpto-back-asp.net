using KarapinhaDAL.Repositories;
using KarapinhaDTO.Time;
using KarapinhaShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapainha.Services
{
    public class TimeService : ITimeService
    {
        private readonly TimeRepository _repository;

        public TimeService()
        {
            _repository = new TimeRepository();
        }

        public TimeDto GetById(int id)
        {
            var time = _repository.GetById(id);
            return TimeMappers.ToTimeDto(time);
        }

        public IEnumerable<TimeDto> GetAll()
        {
            var times = _repository.GetAll();
            return times.Select(x => TimeMappers.ToTimeDto(x));
        }

        public void CreateTime(TimeCreateDto bookingCreateDto)
        {
            var time = TimeMappers.CreateToTime(bookingCreateDto);
            _repository.Add(time);
            _repository.Save();
        }

        public void DeleteTime(int id)
        {
            var time = _repository.GetById(id);
            if (time != null)
            {
                _repository.Delete(time);
                _repository.Save();
            }
        }        

        public void UpdateTime(TimeCreateDto bookingCreateDto)
        {
            throw new NotImplementedException();
        }
    }
}
