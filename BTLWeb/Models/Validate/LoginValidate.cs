using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTLWeb.Models.Validate
{
    public class LoginValidate
    {
        [Required(ErrorMessage = "username can not be null")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "password can not be null")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}