using AgileManager.Web.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileManager.Web.Controllers
{
    public class BacklogController : Controller
    {
        //
        // GET: /Backlog/
        public ActionResult Index()
        {
            int backlogId = Int32.Parse(Session["BacklogId"].ToString()),
                productId = Int32.Parse(Session["ProductId"].ToString());

            var sprintRepo = new SprintRepository();
            var backlogRepo = new BacklogRepository();
            var epicRepo = new EpicRepository();

            bool isSprintActive;
            var sprintTasks = sprintRepo.GetCurrentSprintTasks(productId, out isSprintActive);

            var model = new BacklogModel()
            {
                BacklogItems = backlogRepo.GetBacklogTasks(backlogId),
                SprintItems = sprintTasks,
                Epics = epicRepo.GetEpicsForBacklog(backlogId),
                IsSprintActive = isSprintActive,
                SprintName = sprintRepo.GetCurrentSprintName(productId)
            };

            return View(model);
        }
	}
}