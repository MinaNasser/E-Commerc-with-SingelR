using EF_Core;
using EF_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Manegers
{
    public class CategoryManager : BaseManager<Category>
    {

        public CategoryManager(EShopContext eShopContext) : base(eShopContext)
        {

        }

    }
}
