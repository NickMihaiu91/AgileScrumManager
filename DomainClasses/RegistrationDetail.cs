using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class RegistrationDetail : BaseClass
    {
        public string Email { get; set; }

        public string RegistrationCode { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime EmailSentAt { get; set; }

        public bool RegistrationCodeUsed { get; set; }
    }
}
