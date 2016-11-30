using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgileScrumManager.Web.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required !")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required !")]
        public string Password { get; set; }
    }
}