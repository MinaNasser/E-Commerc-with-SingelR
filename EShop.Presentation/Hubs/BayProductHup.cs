using EF_Core.Models;
using EShop.Manegers;
using Microsoft.AspNetCore.SignalR;

public class BayProductHup : Hub
{
    private readonly ProductManager _productManager;

    public BayProductHup(ProductManager productManager)
    {
        _productManager = productManager;
    }

    public async Task BuyProduct(int productId, int quantity)
    {
        try
        {
            bool success = await _productManager.ReduceStockAsync(productId, quantity);

            if (success)
            {
                int newQty = await _productManager.GetQuantityAsync(productId);
                await Clients.All.SendAsync("UpdateProductQuantity", productId, newQty);
            }
            else
            {
                await Clients.Caller.SendAsync("PurchaseFailed", "❌ Not enough stock or invalid product.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Exception in BuyProduct: " + ex.Message);
            throw;
        }
    }


    public async Task JoinProductGroup(int productId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, productId.ToString());
    }
}
