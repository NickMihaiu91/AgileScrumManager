using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgileManager.Web.Models
{
    public class ChangePasswordModel : ResetPasswordModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Old password is required !")]
        [MinLength(10, ErrorMessage = "Password must be at least 10 characters long.")]
        [DisplayName("Old Password")]
        public string OldPassword { get; set; }
    }
}