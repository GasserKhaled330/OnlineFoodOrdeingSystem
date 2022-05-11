using OnlineFoodOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.ViewModels
{
    public class RegisterViewModel
    {
        public Customer Customer { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}