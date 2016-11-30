using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class WorkLoadRepository : BaseRepository<WorkLoad>
    {
        public void AddWorkLoad(int taskId, int userId, WorkLoad workload)
        {
            workload.AddedAt = DateTime.Now;
            workload.TaskId = taskId;
            workload.UserId = userId;

            _context.WorkLoads.Add(workload);
            _context.SaveChanges();
        }

        public float GetTotalWorkedHoursForTask(int taskId)
        {
            return _context.WorkLoads.Where(x => x.TaskId == taskId).Sum(y => (float?)y.Amount) ?? 0;
        }
    }
}
