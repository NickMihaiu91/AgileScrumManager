using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileManager.Web.WebAPI
{
    public class BacklogController : ApiController
    {
        // POST api/backlog
        // assign task to backlog, unassign from current sprint
        public void Post([FromBody]int value)
        {
            var taskRepo = new TaskRepository();

            taskRepo.UnassignTaskFromCurrentSprint(value);
        }
    }
}
