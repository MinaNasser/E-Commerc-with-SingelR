using System.ComponentModel.DataAnnotations;

namespace EShop.ViewModels
{
    public class UserRegisterVM
    {
        [Required(ErrorMessage ="This Field is Required")]
        [StringLength(100,MinimumLength =6,ErrorMessage ="Value Must at least 6 letter ")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Value Must at least 6 letter ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Value Must at least 6 letter ")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Value Must at least 8 letter ")]
        [DataType(DataType.Password)]
        [Compare("ConformPassord")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Value Must at least 6 letter ")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConformPassord { get; set; }

        [Required(ErrorMessage = "Role is Required")]
        public string Role { get; set; }


    }
}
