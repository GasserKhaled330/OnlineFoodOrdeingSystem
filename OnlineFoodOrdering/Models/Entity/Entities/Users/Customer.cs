using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models
{
    public class Customer 
    {
        [Key]
        public int customerId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Contact Number")]
        public string contactNumber { get; set; }

        
        public ShoppingCart ShoppingCart { get; set; }

    }
}