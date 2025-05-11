using Microsoft.AspNetCore.Mvc;

namespace EShop.Presentation.Areas.Vendor.Controllers
{
    [Area("vendor")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
