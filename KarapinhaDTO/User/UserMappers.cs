using KarapinhaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.User
{
    public static class UserMappers
    {
        public static UserDto ToUserDto (UserModel user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAdress,
                IdCard = user.IdCard,
                PhoneNumber = user.PhoneNumber,
                PhotoUrl = user.PhotoUrl,
                Role = user.Role,
                Status = user.Status,
                Username = user.Username,
            };
        }

        public static UserModel CreateToUser (UserCreateDto user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAdress = user.EmailAddress,
                IdCard = user.IdCard,
                PhoneNumber = user.PhoneNumber,
                PhotoUrl = user.PhotoUrl,
                Role = user.Role,
                Username = user.Username,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,
                Status = "pending"
            };
        }

        public static void UpdateUser(UserModel existingUser, UserCreateDto dto)
        {
            if (!string.IsNullOrEmpty(dto.FirstName))
                existingUser.FirstName = dto.FirstName;

            if (!string.IsNullOrEmpty(dto.LastName))
                existingUser.LastName = dto.LastName;

            if (!string.IsNullOrEmpty(dto.EmailAddress))
                existingUser.EmailAdress = dto.EmailAddress;

            if (dto.PhoneNumber != 0)
                existingUser.PhoneNumber = dto.PhoneNumber;

            if (!string.IsNullOrEmpty(dto.PhotoUrl))
                existingUser.PhotoUrl = dto.PhotoUrl;

            if (!string.IsNullOrEmpty(dto.IdCard))
                existingUser.IdCard = dto.IdCard;

            if (!string.IsNullOrEmpty(dto.Password))
                existingUser.Password = dto.Password;

            if (!string.IsNullOrEmpty(dto.ConfirmPassword))
                existingUser.ConfirmPassword = dto.ConfirmPassword;

            if (!string.IsNullOrEmpty(dto.Username))
                existingUser.Username = dto.Username;
        }

    }
}
