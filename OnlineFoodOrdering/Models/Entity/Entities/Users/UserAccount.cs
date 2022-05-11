using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models
{
    public class UserAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAccount()
        {
            this.UserRolesMappings = new HashSet<UserRolesMapping>();
        }
        [Key]
        public int ID { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        [NotMapped]
        [StringLength(50)]
        [Required(ErrorMessage = "Does not Match!")]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "Password not Matched!")]
        public string ConfirmPassword { get; set; }
        
       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRolesMapping> UserRolesMappings { get; set; }
    }

}