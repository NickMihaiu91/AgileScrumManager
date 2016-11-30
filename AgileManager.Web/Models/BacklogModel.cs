using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileManager.Web.Models
{
    public class BacklogModel
    {
        public ICollection<DomainClasses.Task> BacklogItems { get; set; }

        public ICollection<DomainClasses.Epic> Epics { get; set; }

        public ICollection<DomainClasses.Task> SprintItems { get; set; }

        public bool IsSprintActive { get; set; }

        public string SprintName { get; set; }
    }
}