using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileManager.Web.Models
{
    public class SprintModel
    {
        public ICollection<DomainClasses.Task> TodoItems { get; set; }

        public ICollection<DomainClasses.Task> InDevelopmentItems { get; set; }

        public ICollection<DomainClasses.Task> InTestingItems { get; set; }

        public ICollection<DomainClasses.Task> DoneItems { get; set; }

        public bool IsSprintActive { get; set; }
    }
}