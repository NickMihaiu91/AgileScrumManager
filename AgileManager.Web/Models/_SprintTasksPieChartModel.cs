using DomainClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileManager.Web.Models
{
    public class _SprintTasksPieChartModel
    {
        public string label { get; set; }

        public int data { get; set; }

        public static ICollection<_SprintTasksPieChartModel> GetData(ICollection<DomainClasses.Task> currentSprintTasks)
        {
            if (currentSprintTasks == null)
                return null;

            if (currentSprintTasks.Count < 1)
                return null;

            var dataCollection = new List<_SprintTasksPieChartModel>();

            foreach (TaskStatus taskStatus in (TaskStatus[])Enum.GetValues(typeof(TaskStatus)))
            {
                if (taskStatus == TaskStatus.Reconsider)
                    continue;

                dataCollection.Add(new _SprintTasksPieChartModel { 
                    label = taskStatus.ToString(),
                    data = currentSprintTasks.Where(x => x.TaskStatus == taskStatus).Count()
                });
            }

            return dataCollection;
        }
    }
}