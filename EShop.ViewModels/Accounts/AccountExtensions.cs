using EF_Core.Models;
namespace EShop.ViewModels
{
    public static class AccountExtensions
    {
        public static User ToModel(this UserRegisterVM viewmodel)
        {
            return new User
            {
                UserName = viewmodel.UserName,
                Email = viewmodel.Email,
                PhoneNumber = viewmodel.PhoneNumber,
            };
        }
    }
}
