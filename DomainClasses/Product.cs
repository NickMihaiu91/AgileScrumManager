using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Product : BaseClass
    {
        private ICollection<User> _productOwners;
        private ICollection<Team> _teams;

        public Product()
        {
            _productOwners = new List<User>();
            _teams = new List<Team>();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A product name is required !")]
        public string Name { get; set; }

        [ForeignKey("Backlog")]
        public int BacklogId { get; set; }

        public Backlog Backlog { get; set; }

        public virtual ICollection<Team> Teams
        {
            get { return _teams; }
            set { _teams = value; }
        }

        public virtual ICollection<User> ProductOwners
        {
            get { return _productOwners; }
            set { _productOwners = value; }
        }
        
    }
}
