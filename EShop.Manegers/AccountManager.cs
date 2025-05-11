using EF_Core;
using EF_Core.Models;
using EShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace EShop.Manegers
{
    public class AccountManager:BaseManager<User>
    {
        private UserManager<User> UserManager;
        private SignInManager<User> signInManager;

        public AccountManager(
            EShopContext context,
            UserManager<User> _UserManager,
            SignInManager<User> _signInManager
            )
            : base(context)
        {
            UserManager = _UserManager;
            signInManager = _signInManager;

        }


        public async Task<IdentityResult> Register(UserRegisterVM userRegister)
        {

            var res=  await UserManager.CreateAsync(userRegister.ToModel(), userRegister.Password);
            if (res.Succeeded)
            {
                User user =await UserManager.FindByNameAsync(userRegister.UserName);

                res =  await  UserManager.AddToRoleAsync(user, userRegister.Role);
                return res;
            }
            return res;
        }

        public async Task<SignInResult> Login(UserLoginVM vmodel)
        {
            //if correct Email
            var User = await UserManager.FindByEmailAsync(vmodel.Method);
            if(User != null)
             return await  signInManager.PasswordSignInAsync(User, vmodel.Password, true, true);
            else
             return await  signInManager.PasswordSignInAsync(vmodel.Method, vmodel.Password, true, true);
        }

        public async Task<User> FindByUserName (string userName)
        {
            return await UserManager.FindByNameAsync(userName);
        }
        public async Task<User> FindByEmail(string email)
        {
            return await UserManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRoles(User user)
        {
            return await UserManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> AsignUserToRole(User user,string newrole)
        {
            return await UserManager.AddToRoleAsync(user,newrole);
        }


        public async Task Signout()
        {
             await signInManager.SignOutAsync();
        }

    }
}
