using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgileManager.Web.Models
{
    public class UserRegistrationModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Firstname is required !")]
        public string Firstname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lastname is required !")]
        public string Lastname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required !")]
        [Editable(false)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required !")]
        [MinLength(10, ErrorMessage = "Password must be at least 10 characters long.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password confirmation is required !")]
        [MinLength(10, ErrorMessage = "Password must be at least 10 characters long.")]
        [DisplayName("Confirm Password")]
        public string ConfirmationPassword { get; set; }
    }
}