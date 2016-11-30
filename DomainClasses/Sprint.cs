using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class Sprint : BaseClass
    {
        private ICollection<Task> _tasks;

        public Sprint()
        {
            _tasks = new List<Task>();
        }

        public string Name { get; set; }

        public Team AsignedTeam { get; set; }

        public Product Product { get; set; }

        public DateTime StartDate { get; set; }

        [DisplayName("End date")]
        public DateTime EndDate { get; set; }

        public bool IsCanceled { get; set; }

        [DisplayName("Sprint goal")]
        public string SprintGoal { get; set; }

        public int? Velocity { get; set; }
       
        public virtual ICollection<Task> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }
        
    }
}
