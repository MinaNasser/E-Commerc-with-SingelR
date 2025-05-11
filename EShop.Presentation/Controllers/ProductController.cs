using EF_Core.Models;
using EShop.Manegers;
using EShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EShop.Presentation.Controllers
{

    public class ProductController : Controller
    {
        private ProductManager ProductManager;
        private CategoryManager CategoryManager;
        private VendorManager VendorManager;
        private CommentManager commentsManger;
        public ProductController(ProductManager pmanager, CategoryManager cmanager , VendorManager vendor, CommentManager manager)
        {
            ProductManager = pmanager;
            CategoryManager = cmanager;
            VendorManager = vendor;
            commentsManger = manager;
        }

        //    .... /product/index
        //    .... /product
        public IActionResult Index(string searchText = "", decimal price = 0,
            int categoryId = 0, string vendorId = "", int pageNumber = 1,
            int pageSize = 3)
        {
            ViewData["CategoriesList"] = GetCategories();

            var list = ProductManager.Search(categoryId: categoryId, vendorId: vendorId,
                searchText: searchText, price: price, pageNumber: pageNumber, pageSize: pageSize);
            return View(list);
        }

        [Authorize(Roles = "Provider")]
        public IActionResult VendorList(string searchText = "", decimal price = 0,
           int categoryId = 0, int pageNumber = 1,
           int pageSize = 3)
        {

            ViewData["CategoriesList"] = GetCategories();
            var myID = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var list = ProductManager.Search(categoryId: categoryId, vendorId: myID,
                searchText: searchText, price: price, pageNumber: pageNumber, pageSize: pageSize);
            return View("index", list);
        }


        [Authorize(Roles = "Provider,Admin")]
        [HttpGet]
        public IActionResult Add()
        {


            ViewData["CategoriesList"] = GetCategories();
            //cast  

            ViewBag.Title = "Welcome";
            //no cast
            return View();
        }
        [Authorize(Roles = "Provider,Admin")]

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel viewModel)
        {
            string vendorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            viewModel.VendorId = vendorId;

            // ✅ تحقق من وجود Vendor باستخدام VendorManager
            var vendor = VendorManager.GetById(v => v.UserId == vendorId);
            if (vendor == null)
            {
                VendorManager.AddAsync(new Vendor
                {
                    UserId = vendorId
                });
            }

            if (ModelState.IsValid)
            {
                foreach (var file in viewModel.Attachments)
                {
                    string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Products", file.FileName);

                    using var fileStream = new FileStream(savePath, FileMode.Create);
                    file.CopyTo(fileStream);

                    viewModel.Paths.Add($"/Images/Products/{file.FileName}");
                }

                ProductManager.AddAsync(viewModel.ToModel());
                return RedirectToAction("Index");
            }

            ViewData["CategoriesList"] = GetCategories();
            return View();
        }

        private List<SelectListItem> GetCategories()
        {
            return CategoryManager.Get()
            .Select(cat => new SelectListItem(cat.Name, cat.Id.ToString())).ToList();
        }
        public IActionResult Details(int id)
        {
            var product = ProductManager.GetByIdWithIncludes(
                p => p.Id == id
                
            // ❌ لا نضمّن Comments هنا
            );

            if (product == null)
                return NotFound();

            // 🟢 حمّل التعليقات يدويًا
            var comments = commentsManger.GetCommentsByProductId(id);

            var viewModel = product.ToDetailsVModel();
            viewModel.Comments = comments.ToList();

            return View(viewModel);
        }




    }
}
