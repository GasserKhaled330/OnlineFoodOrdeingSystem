using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models.Application.ViewModels
{
    public class OrderRequestViewModel
    {
        [Required(ErrorMessage = "Please Enter a Name")]
        [Display(Name = "SHIP TO NAME")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Address")]
        [Display(Name = "SHIP TO Address")]
        public string Address { get; set; }

    }
}