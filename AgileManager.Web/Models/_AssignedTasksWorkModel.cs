using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AgileManager.Web.Models
{
    public class _AssignedTasksWorkModel
    {
        [DisplayName("Task name")]
        public string TaskName { get; set; }

        [DisplayName("Worked hours")]
        public float WorkedHours { get; set; }

        public int TaskId { get; set; }
    }
}