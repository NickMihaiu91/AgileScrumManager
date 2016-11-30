using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class TaskRepository : BaseRepository<DomainClasses.Task>
    {

        public void AddTask(DomainClasses.Task task, int backlogId, int reporterId)
        {
            task.CreatedAt = DateTime.Now;
            task.EditedAt = DateTime.Now;
            task.Reporter = _context.Users.Find(reporterId);
            task.BacklogId = backlogId;

            _context.Tasks.Add(task);
            _context.SaveChanges();

        }

        public DomainClasses.Task GetTaskWithRelevantData(int taskId)
        {
            return _context.Tasks.Where(x => x.Id == taskId)
                .Include(y => y.Comments)
                .Include(y => y.Assignee)
                .Include(y => y.Reporter)
                .Include(y => y.WorkLoads)
                .FirstOrDefault();
        }

        public bool EditTask(DomainClasses.Task task)
        {
            var storedTask = GetById(task.Id);

            storedTask.Title = task.Title;
            storedTask.Description = task.Description;
            storedTask.TaskType = task.TaskType;
            storedTask.TaskStatus = task.TaskStatus;
            storedTask.TaskPriority = task.TaskPriority;

            storedTask.EditedAt = DateTime.Now;

            _context.SaveChanges();

            return true;
        }

        public void AssignTaskToUser(int taskId, int userId)
        {
            var task = GetById(taskId);

            task.Assignee = _context.Users.Find(userId);

            _context.SaveChanges();
        }

        public void AssignTaskToCurrentSprint(int taskId)
        {
            var task = GetById(taskId);

            if (task == null)
                return;

            var product = _context.Products.Where(x => x.BacklogId == task.BacklogId).FirstOrDefault();

            if(product == null)
                return;

            var sprintRepo = new SprintRepository();
            var sprint = sprintRepo.GetCurrentSprintForProduct(product.Id);

            if (sprint == null)
                return;

            task.SprintId = sprint.Id;

            _context.SaveChanges();
        }

        public void UnassignTaskFromCurrentSprint(int taskId)
        {
            var task = GetById(taskId);

            if(task != null)
                task.SprintId = null;

            _context.SaveChanges();
        }

        public ICollection<DomainClasses.Task> QueryTasks(int backlogId, string title, DomainClasses.Enums.TaskPriority taskPriority,
            DomainClasses.Enums.TaskStatus taskStatus, DomainClasses.Enums.TaskType taskType)
        {
            return _context.Tasks.Where(x => x.BacklogId == backlogId && x.TaskStatus == taskStatus && x.TaskPriority == x.TaskPriority && x.TaskType == taskType && x.Title.Contains(title)).ToList();
        }

        public ICollection<DomainClasses.Task> GetAssignedTasksForUser(int userId)
        {
            return _context.Tasks.Where(x => x.Assignee.Id == userId).Include(x => x.WorkLoads).ToList();
        }

    }
}
