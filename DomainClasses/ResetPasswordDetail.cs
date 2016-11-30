using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class ResetPasswordDetail : BaseClass
    {
        public string ResetPasswordCode { get; set; }

        public DateTime RequestedAt { get; set; }

        public bool PasswordReseted { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
