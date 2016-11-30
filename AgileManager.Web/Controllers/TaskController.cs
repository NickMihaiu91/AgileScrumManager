using DataLayer.Repositories;
using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileManager.Web.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Task/Details/5
        public ActionResult Details(int id)
        {
            var taskRepo = new TaskRepository();
            var workRepo = new WorkLoadRepository();

            var task = taskRepo.GetTaskWithRelevantData(id);

            task.TotalWorkHours = workRepo.GetTotalWorkedHoursForTask(id);

            return View(task);
        }

        //
        // GET: /Task/Create
        public ActionResult Create()
        {
            return View(new DomainClasses.Task() { TaskType = DomainClasses.Enums.TaskType.Story, TaskPriority = DomainClasses.Enums.TaskPriority.P3 });
        }

        //
        // POST: /Task/Create
        [HttpPost]
        public ActionResult Create(DomainClasses.Task model)
        {
            try
            {
                int backlogId = Int32.Parse(Session["BacklogId"].ToString()),
                    userId = Int32.Parse(Session["UserId"].ToString());

                var repo = new TaskRepository();

                repo.AddTask(model, backlogId, userId);

                return RedirectToAction("Index", "Backlog");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Task/Edit/5
        public ActionResult Edit(int id)
        {
            var taskRepo = new TaskRepository();
 
            return View(taskRepo.GetById(id));
        }

        //
        // POST: /Task/Edit/5
        [HttpPost]
        public ActionResult Edit(DomainClasses.Task model)
        {
            try
            {
                var taskRepo = new TaskRepository();

                taskRepo.EditTask(model);

                return RedirectToAction("Details", new { id = model.Id });
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Task/AssignTask/5
        public ActionResult AssignTask(int id)
        {
            int userId = Int32.Parse(Session["UserId"].ToString());
            var taskRepo = new TaskRepository();

            taskRepo.AssignTaskToUser(id, userId);

            return RedirectToAction("Details", new {id = id});
        }


        //
        // GET: /Task/WorkLog/5
        public ActionResult WorkLog(int id)
        {
            ViewBag.id = id;
            return View();
        }

        //
        // POST: /Task/WorkLog/5
        [HttpPost]
        public ActionResult WorkLog(int id, WorkLoad model)
        {
            try
            {
                var workRepo = new WorkLoadRepository();
                int userId = Int32.Parse(Session["UserId"].ToString());

                workRepo.AddWorkLoad(id, userId, model);

                return RedirectToAction("Details", new { id = id });
            }
            catch
            {
                return View();
            }
        }
        
 
    }
}
