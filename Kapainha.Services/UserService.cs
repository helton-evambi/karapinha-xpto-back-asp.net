using BCrypt.Net;
using Karapinha.Services;
using KarapinhaDAL.Repositories;
using KarapinhaDTO.Category;
using KarapinhaDTO.Professional;
using KarapinhaDTO.User;
using KarapinhaShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapainha.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;
        private readonly EmailService _emailService;

        public UserService()
        {
            _repository = new UserRepository();
            _emailService = new EmailService();
        }

        public UserDto GetById(int id)
        {
            var user = _repository.GetById(id);
            return UserMappers.ToUserDto(user);
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _repository.GetAll();
            return users.Select(x => UserMappers.ToUserDto(x));
        }

        public UserDto GetByUsername(string username)
        {
            var user = _repository.GetByUsername(username);
            return UserMappers.ToUserDto(user);
        }

        public UserDto GetByEmail(string email)
        {
            var user = _repository.GetByEmail(email);
            return UserMappers.ToUserDto(user);
        }

        public void CreateUser(UserCreateDto userCreateDto)
        {
            userCreateDto.Password = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);
            var user = UserMappers.CreateToUser(userCreateDto);
            try
            {
                _repository.Add(user);
                _repository.Save();

                if(userCreateDto.Role == "user")
                {
                    _emailService.EnviarEmailNotificacaoCadastro(userCreateDto);
                }
                if(userCreateDto.Role == "administrativo")
                {
                    _emailService.EnviarEmailCredenciaisAdmin(userCreateDto);
                }


             
            }
            catch (Exception ex)
            {
                throw new Exception("Mensagem de erro específica", ex);
            }
            
        }

        public void DeleteUser(int id)
        {
            var user = _repository.GetById(id);
            if (user != null)
            {
                _repository.Delete(user);
                _repository.Save();
            }
        }

        public void UpdateUser(int id, UserCreateDto userCreateDto)
        {
            if(userCreateDto.Password != null)
                userCreateDto.Password = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);

            var existingUser = _repository.GetById(id) ?? throw new KeyNotFoundException("User not found");
            UserMappers.UpdateUser(existingUser, userCreateDto);

            _repository.Update(existingUser);
            if(existingUser.Role == "administrative")
            {
                UpdateUserStatus(id, "active");
            } 
            _repository.Save();
        }

        public void UpdateUserStatus(int id, string status)
        {
            var existingUser = _repository.GetById(id) ?? throw new KeyNotFoundException("User not found");
            existingUser.Status = status;

            _repository.UpdateStatus(existingUser);
            _repository.Save();

           /* if (status == "active") { 
                _emailService.EnviarEmailAtivacao(UserMappers.ToUserDto(existingUser);
            } */
        }
    }
}
