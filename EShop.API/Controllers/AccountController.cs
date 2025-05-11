using EShop.Services;
using EShop.ViewModels;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Text;

namespace EShop.API.Controllers
{
    [ApiController]
    [Route("api/{Controller}")]
    public class AccountController : ControllerBase
    {
        private AccountServices accountService;
        public AccountController(AccountServices _accountServices)
        {
            accountService = _accountServices;
        }

       
        [HttpPost("Register")]

        public async Task<IActionResult> Register(UserRegisterVM user)
        {
            
            if (ModelState.IsValid)
            {
                var res = await accountService.CreateAccount(user);
                if (res.Succeeded)
                {
                    return new JsonResult(new
                    {
                        Massage = "Your Account Added Successfully ,Go to Login",
                        Status = 200
                    });
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    res.Errors.ForEach(err => stringBuilder.Append(err.Description));
                    return new JsonResult(new
                    {
                        Massage = stringBuilder.ToString(),
                        Status = 400
                    });
                }
            }
            StringBuilder stringBuilder1 = new StringBuilder();
            foreach (var item in ModelState.Values)
            {
                foreach(var err in item.Errors)
                {
                    stringBuilder1.Append(err.ErrorMessage);
                }
            }

            return new JsonResult(new
            {
                Massage = stringBuilder1.ToString(),
                Status = 400
            });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserLoginVM vmodel)
        {
            if (ModelState.IsValid)
            {
                var res = await accountService.LoginWithToken(vmodel);
                if (res == null)
                {
                    return new JsonResult(new
                    {
                        Massage = "Sorry Invalid Email Or User Name Or Password",
                        Status = 400
                    });
                }
                else if (res == "")
                {
                    return new JsonResult(new
                    {
                        Massage = "Sorry try again Later!!!! Your Accout under Review",
                        Status = 400
                    });
                }
                else
                {
                    var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                    return new JsonResult(new
                    {
                        Massage = "Logged in Successfully",
                        Status = 200,
                        Token= res,
                        Role = role
                    });

                }
            }
            StringBuilder stringBuilder1 = new StringBuilder();
            foreach (var item in ModelState.Values)
            {
                foreach (var err in item.Errors)
                {
                    stringBuilder1.Append(err.ErrorMessage);
                }
            }

            return new JsonResult(new
            {
                Massage = stringBuilder1.ToString(),
                Status = 400
            });

        }

        public async Task<IActionResult> Signout()
        {
            await accountService.Signout();
            return new JsonResult(new
            {
                Massage = "Sign out Successfully",
                Status = 200
            });
        }
    }
}
