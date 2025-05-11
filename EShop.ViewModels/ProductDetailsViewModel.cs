namespace EShop.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public string VendorName { get; set; }

        public DateTime CreatedAt { get; set; }


        public  List<string> Images { get; set; } 

    }
}
