using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace work.mvc.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Adınızı daxil edin")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Ad 3-15 simvol aralığında olmalıdır")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyadınızı daxil edin")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Soyad 3-15 simvol aralığında olmalıdır")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email təkrarı qeyd edilməlidir")]
        [DataType(DataType.EmailAddress)]
        [Compare("Email", ErrorMessage = "Email təkrarı yanlış")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email qeyd edilməlidir")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email formatına uyğun deyil")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsApproved { get; set; }

        [Required(ErrorMessage = "Şifrə daxil edin")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Şifrə 6-20 simvol aralığında olmalıdır")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrə təkrarını daxil edin")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifrələr eyni deyil")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Şifrə 6-20 simvol aralığında olmalıdır")]
        public string RePassword { get; set; }
    }
}
