using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrdering.Models
{
    public class FoodItem
    {
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter a Food Item name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public double price { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public List<CartItem> cartItems { get; set; }

    }

}