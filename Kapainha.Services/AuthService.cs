using KarapinhaDAL.Repositories;
using KarapinhaDTO.User;
using KarapinhaShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapainha.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserRepository _userRepository;

        public AuthService()
        {
            _userRepository = new UserRepository();
        }
        public UserDto Authenticate(string identifier, string password)
        {
            var user = _userRepository.GetByUsername(identifier);
            if (user == null)
            {
                user = _userRepository.GetByEmail(identifier);
            }
            if (user == null || !VerifyPassword(user.Password, password))
            {
                return null;
            }
            return UserMappers.ToUserDto(user);

        }
        private bool VerifyPassword(string storedHash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}
