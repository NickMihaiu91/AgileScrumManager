using DomainClasses.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AgileManager.Web.Models
{
    public class TaskSearchModel
    {
        public QueryModel SearchModel { get; set; }

        public ICollection<DomainClasses.Task> Results { get; set; }

        public bool DisplayNoResultsMessage { get; set; }
    }

    public class QueryModel
    {
        [DisplayName("Title contains")]
        public string Title { get; set; }

        [DisplayName("Task priority")]
        public TaskPriority TaskPriority { get; set; }

        [DisplayName("Task type")]
        public TaskType TaskType { get; set; }

        [DisplayName("Task status")]
        public DomainClasses.Enums.TaskStatus TaskStatus { get; set; }
    }
}