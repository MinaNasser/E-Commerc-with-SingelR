using EF_Core;
using EF_Core.Models;

namespace EShop.Manegers
{
    public class ClientManager:BaseManager<Client>
    {
        public ClientManager(EShopContext context) : base(context)
        {

        }
    }
}
