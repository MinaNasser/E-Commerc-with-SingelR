using EShop.Manegers;
using EShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace EShop.Presentation.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private RoleManager RoleManager;
        public RoleController(RoleManager roleManager)
        {
            RoleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var list = RoleManager.GetList().Select(r => new RoleViewModel
            {
                Id = r.Id,
                Name = r.Name,
            }).ToList();

            //ViewBag.Invalid = 0;
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> Add(string roleName)
        {
            if (roleName.IsNullOrEmpty())
            {
                ViewBag.Invalid = 1;
                var list = RoleManager.GetList().Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                }).ToList();
                return View(list);
            }
            else
            {
                var res =  await RoleManager.Add(roleName);
                if (res.Succeeded)
                {
                    ViewBag.Invalid = 2;
                }
                else
                {
                    ViewBag.Invalid = 1;
                }
                var list = RoleManager.GetList().Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                }).ToList();
                return View(list);
            }

        }



    }
}
