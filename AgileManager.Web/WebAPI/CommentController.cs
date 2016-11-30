using DataLayer.Repositories;
using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileManager.Web.WebAPI
{
    public class CommentController : ApiController
    {
        // GET api/comment
        public IEnumerable<Comment> Get(int id)
        {
            var repo = new CommentRepository();
            return repo.GetCommentsForTask(id);
        }

        // POST api/comment
        public void Post(int id, [FromBody]PostCommentHelper message)
        {
            var repo = new CommentRepository();
            repo.AddComment(message.userId, id, message.value);
        }

        // PUT api/comment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/comment/5
        public void Delete(int id)
        {
        }
    }

    public class PostCommentHelper
    {
        public int userId { get; set; }

        public string value { get; set; }
    }
}
