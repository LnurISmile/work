using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace work.mvc.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email qeyd edilməlidir")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email formatına uyğun deyil")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrə daxil edin")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Şifrə 6-20 simvol aralığında olmalıdır")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
