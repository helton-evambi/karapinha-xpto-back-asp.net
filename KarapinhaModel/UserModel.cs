using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarapinhaModel
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public int PhoneNumber {  get; set; }
        public string PhotoUrl { get; set; }
        public string IdCard { get; set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role {  get; set; }
        public string Status {  get; set; }

        public virtual ICollection<BookingModel> Bookings { get; set; }

        public UserModel()
        {
            Bookings = new HashSet<BookingModel>();
        }

    }
    
}
