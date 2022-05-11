using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models
{
    public class UserRolesMapping
    {
        public int ID { get; set; }
     
        public int userID { get; set; }
  
        public int roleID { get; set; }
        [ForeignKey("roleID")]
        public virtual RoleMaster RoleMaster { get; set; }
        [ForeignKey("userID")]
        public virtual UserAccount UserAccount { get; set; }
    }
}