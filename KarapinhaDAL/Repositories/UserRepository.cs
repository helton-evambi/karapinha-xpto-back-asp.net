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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository()
        {
            context = new AppDbContext();
        }

        public UserModel GetById(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return context.Users;
        }

        public UserModel GetByUsername(string username)
        {
            return context.Users.FirstOrDefault(x => x.Username == username);
        }

        public UserModel GetByEmail(string email)
        {
            return context.Users.FirstOrDefault(x => x.EmailAdress == email);
        }
        public void Add(UserModel user)
        {
            context.Users.Add(user);
        }


        public void Delete(UserModel user)
        {
            if (context.Entry(user).State == EntityState.Detached)
            {
                context.Users.Attach(user);
            }
            context.Users.Remove(user);
        }

        public void Update(UserModel user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void UpdateStatus(UserModel user)
        {
            context.Users.Attach(user);
            context.Entry(user).Property(u => u.Status).IsModified = true;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}
