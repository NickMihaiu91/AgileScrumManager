using DomainClasses.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class User : BaseClass
    {
        [DisplayName("First Name")]
        public string Firstname { get; set; }

        [DisplayName("Last Name")]
        public string Lastname { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", Firstname, Lastname);
            }
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        [DisplayName("Role")]
        public UserType UserType { get; set; }

        [ForeignKey("RegistrationDetail")]
        public int? RegistrationId { get; set; }

        //navigation

        public RegistrationDetail RegistrationDetail { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}
