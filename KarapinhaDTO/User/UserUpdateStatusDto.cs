using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaDTO.User
{
    public class UserUpdateStatusDto
    {
        [Required]
        public string Status { get; set; }
    }
}
