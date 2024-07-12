using KarapinhaDTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Services
{
    public interface IUserService
    {
        UserDto GetById(int id);
        IEnumerable<UserDto> GetAll();
        UserDto GetByUsername(string username);
        UserDto GetByEmail(string email);
        void CreateUser(UserCreateDto userCreateDto);
        void UpdateUser(int id, UserCreateDto userCreateDto);
        void UpdateUserStatus (int id, string status);
        void DeleteUser(int id);
    }
}
