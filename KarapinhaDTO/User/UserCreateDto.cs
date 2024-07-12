using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.User
{
    public class UserCreateDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public int PhoneNumber { get; set; }

        public string PhotoUrl { get; set; }

        public string IdCard { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }
    }
}
