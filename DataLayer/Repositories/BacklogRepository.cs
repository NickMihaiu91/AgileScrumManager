using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class BacklogRepository : BaseRepository<Backlog>
    {
        public ICollection<DomainClasses.Task> GetBacklogTasks(int backlogId)
        {
            return _context.Tasks.Where(y => y.BacklogId == backlogId).Where(x => x.SprintId == null).Include(x => x.Assignee).Include(x => x.Epic).ToList();
        }
    }
}
