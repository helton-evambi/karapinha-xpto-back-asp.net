using KarapinhaDTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Services
{
    public interface IAuthService
    {
        UserDto Authenticate(string identifier, string password);
    }
}
