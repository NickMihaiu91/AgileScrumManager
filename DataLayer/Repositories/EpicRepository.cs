using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class EpicRepository :BaseRepository<Epic>
    {
        public ICollection<Epic> GetEpicsForBacklog(int backlogId)
        {
            return _context.Epics.Where(x => x.BacklogId == backlogId).ToList();
        }
    }
}
