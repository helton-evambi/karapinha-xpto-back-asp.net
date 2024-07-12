using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.User
{
    public class LoginDto
    {
    [Required]
        public string Identifier { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
