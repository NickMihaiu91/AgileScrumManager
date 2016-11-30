using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Team : BaseClass
    {
        private ICollection<User> _teamMembers;

        public Team()
        {
            _teamMembers = new List<User>();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A team name is required !")]
        public string Name { get; set; }

        [InverseProperty("Team")]
        public virtual ICollection<User> Members
        {
            get { return _teamMembers; }
            set { _teamMembers = value; }
        }

        [ForeignKey("TeamLeader")]
        public int? TeamLeaderId { get; set; }

        public User TeamLeader { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        public Product Product { get; set; }

    }
}
