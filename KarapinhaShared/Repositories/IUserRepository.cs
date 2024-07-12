using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaShared.Repositories
{
    public interface IUserRepository
    {
        UserModel GetById(int id);
        IEnumerable<UserModel> GetAll();
        UserModel GetByUsername(string username);
        UserModel GetByEmail(string email);
        void Add(UserModel user);
        void Update(UserModel user);
        void UpdateStatus(UserModel satus);
        void Delete(UserModel user);
        void Save();
    }
}
