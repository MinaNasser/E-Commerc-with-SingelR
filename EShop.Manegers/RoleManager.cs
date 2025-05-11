using EF_Core;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
namespace EShop.Manegers
{
    public class RoleManager :BaseManager<IdentityRole>
    {
        RoleManager<IdentityRole> roleManager;
        public RoleManager(EShopContext context, RoleManager<IdentityRole> roleManager) : base(context)
        {
            this.roleManager = roleManager;
        }


        public async Task<IdentityResult> Add(string rolename)
        {
           return await roleManager.CreateAsync(new IdentityRole { Name = rolename });
        }
    }
}
