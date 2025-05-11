using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace EShop.ViewModels
{
    public class MultiLine : ValidationAttribute
    {
       
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string val = value as string;

            if (val.IsNullOrEmpty())
            {
                return new ValidationResult("Please Provide valid Product Description");
            }
            if(val.Split(Environment.NewLine).Length < 2 )
            {
                return new ValidationResult("Please Provide Product Description With Multi Line");
            }
            return ValidationResult.Success;
        }
    }
}
