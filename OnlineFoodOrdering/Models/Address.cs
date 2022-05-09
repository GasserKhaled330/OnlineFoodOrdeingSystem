using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models
{
    public class Address
    {
        [Key]
        public int id { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int appartment { get; set; }
        public Customer customer { get; set; }
    }
}