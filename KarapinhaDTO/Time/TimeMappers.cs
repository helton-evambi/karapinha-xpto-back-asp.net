using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.Time
{
    public static class TimeMappers
    {
        public static TimeDto ToTimeDto (TimeModel time)
        {
            if (time == null)
            {
                return null;
            }
            return new TimeDto
            {
                TimeId = time.TimeId,
                Hour = time.Hour,
                Minute = time.Minute,
            };
        }

        public static TimeModel CreateToTime (TimeCreateDto time)
        {
            return new TimeModel
            {
                Hour = time.Hour,
                Minute = time.Minute,
            };
        }
    }
}
