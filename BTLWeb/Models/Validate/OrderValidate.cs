using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTLWeb.Models.Validate
{
    public class OrderValidate
    {
        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string RequiredDate { get; set; }

        [Required]
        public string Receiver { get; set; }

        [Required]
        public string Address { get; set; }

        public string Description { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}