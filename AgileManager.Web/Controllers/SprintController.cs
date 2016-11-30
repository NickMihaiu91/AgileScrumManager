using AgileManager.Web.Models;
using DataLayer.Repositories;
using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileManager.Web.Controllers
{
    public class SprintController : Controller
    {
        //
        // GET: /Sprint/
        public ActionResult Index()
        {
            int productId = Int32.Parse(Session["ProductId"].ToString());
            var sprintRepo = new SprintRepository();

            bool isSprintActive;
            var tasks = sprintRepo.GetCurrentSprintTasks(productId, out isSprintActive);

            if (tasks == null)
                return View( new SprintModel { IsSprintActive = false });

            var model = new SprintModel()
            {
                TodoItems = tasks.Where(x=>x.TaskStatus == DomainClasses.Enums.TaskStatus.Open).ToList(),
                InDevelopmentItems = tasks.Where(x => x.TaskStatus == DomainClasses.Enums.TaskStatus.Development).ToList(),
                InTestingItems = tasks.Where(x => x.TaskStatus == DomainClasses.Enums.TaskStatus.Testing).ToList(),
                DoneItems = tasks.Where(x => x.TaskStatus == DomainClasses.Enums.TaskStatus.Closed).ToList(),
                IsSprintActive = isSprintActive
            };

            return View(model);
        }

        //
        // GET: /Sprint/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sprint/Create
        [HttpPost]
        public ActionResult Create(Sprint model)
        {
            try
            {
                var sprintRepo = new SprintRepository();
                int productId = Int32.Parse(Session["ProductId"].ToString());

                sprintRepo.AddSprint(model, productId);

                return RedirectToAction("Index", "Backlog");
            }
            catch
            {
                return View(model);
            }          
        }

	}
}