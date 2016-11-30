using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {

        public ICollection<Comment> GetCommentsForTask(int taskId)
        {
            return _context.Comments.Where(x => x.Task.Id == taskId).Include(y => y.PostedBy).OrderByDescending(z => z.PostedAt).ToList();
        }

        public bool AddComment(int userId, int taskId, string commentText)
        {
            var task = _context.Tasks.Find(taskId);
            var user = _context.Users.Find(userId);

            var comment = new Comment()
            {
                Content = commentText,
                PostedAt = DateTime.Now,
                PostedBy = user,
                Task = task
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return true;
        }
    }
}
