using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.User
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public string IdCard { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }
}
