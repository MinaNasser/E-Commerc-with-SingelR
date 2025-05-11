using EF_Core.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.ViewModels
{
    public class AddProductViewModel
    {
        [Required (ErrorMessage ="Please Provide valid Product Name")]
        [StringLength(100,MinimumLength =3 , ErrorMessage ="Product name must contain at least 3 letter and max 100 letter")]
        public string Name { get; set; }


        //[Required(ErrorMessage = "Please Provide valid Product Description")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Product Description must contain at least 10 letter and max 1000 letter")]
        //[MultiLine]
        //[DataType(dataType:DataType.MultilineText)]
        public string Description { get; set; }


        [Range(1,100 ,ErrorMessage = "Quantity must be at least 1 to 100")]
        public int Quantity { get; set; }


        [Required (ErrorMessage = "Please Provide valid Product Price Start from 5")]
        //[DataType(DataType.Currency)]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Please Provide valid Product Category")]
        [DisplayName("Select Product Category")]
        public int CategoryId { get; set; }

        public IFormFileCollection Attachments { get; set; }


        //no requied to be Displayed
        public string VendorId { get; set; } = "";
        public bool IsDelated { get; set; } = false;
        //[NotMapped]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<string> Paths { get; set; } = new List<string>();
    }

    
}
