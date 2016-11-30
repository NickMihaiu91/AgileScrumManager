using AgileManager.Web.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileManager.Web.WebAPI
{
    public class SprintController : ApiController
    {
        // POST api/sprint
        // assign task to current sprint
        public void Post([FromBody]int value)
        {
            var taskRepo = new TaskRepository();

            taskRepo.AssignTaskToCurrentSprint(value);
        }


        // GET api/sprint
        // get data for sprint task pie chart
        public IEnumerable<_SprintTasksPieChartModel> Get(int id)
        {
            bool isSprinActive;
            var repo = new SprintRepository();
            var sprintTasks = repo.GetCurrentSprintTasks(id, out isSprinActive);

            return _SprintTasksPieChartModel.GetData(sprintTasks);
        }

    }
}
