using EF_Core;
using EF_Core.Models;

namespace EShop.Manegers
{
    public class VendorManager:BaseManager<Vendor>
    {
        public VendorManager(EShopContext context) : base(context)
        {

        }
    }
}
