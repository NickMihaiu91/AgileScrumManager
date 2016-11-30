using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgileManager.Web.Models
{
    public class ResetPasswordModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required !")]
        [MinLength(10, ErrorMessage = "Password must be at least 10 characters long.")]
        [DisplayName("New Password")]
        public string NewPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password confirmation is required !")]
        [MinLength(10, ErrorMessage = "Password must be at least 10 characters long.")]
        [DisplayName("Confirm Password")]
        public string ConfirmationPassword { get; set; }
    }
}