using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileManager.Web.Models
{
    public class DashboardModel
    {
        public ICollection<_AssignedTasksWorkModel> AssignedTaskWorkModelCollection { get; set; }
    }
}