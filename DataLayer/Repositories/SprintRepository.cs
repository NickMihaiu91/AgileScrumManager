using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class SprintRepository : BaseRepository<Sprint>
    {
        public Sprint GetCurrentSprintForProduct(int productId)
        {
            return _context.Sprints.Where(x => x.Product.Id == productId && x.IsCanceled == false && x.EndDate > DateTime.Now)
                .OrderByDescending(y => y.StartDate).Include(z => z.Tasks).FirstOrDefault();
        }

        public ICollection<DomainClasses.Task> GetCurrentSprintTasks(int productId, out bool IsSprintActive)
        {
            var sprint = GetCurrentSprintForProduct(productId);

            if (sprint == null)
            {
                IsSprintActive = false;
                return null;
            }

            IsSprintActive = true;
            return sprint.Tasks;
        }

        public bool AddSprint(Sprint sprint, int productId)
        {
            sprint.StartDate = DateTime.Now;
            sprint.Product = _context.Products.Find(productId);
            // TODO sprint.AsignedTeam

            _context.Sprints.Add(sprint);
            _context.SaveChanges();

            return true;
        }

        public string GetCurrentSprintName(int productId)
        {
            var currentSprint = GetCurrentSprintForProduct(productId);

            if(currentSprint == null)
                return null;

            return currentSprint.Name;
        }
    }
}
