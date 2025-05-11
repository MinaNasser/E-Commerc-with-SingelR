using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ViewModels
{
    public class UserLoginVM
    {
        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Value Must at least 6 letter ")]
        public string Method { get; set; }



        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Value Must at least 8 letter ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
