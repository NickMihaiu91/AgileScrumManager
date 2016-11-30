using AgileManager.Web.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileManager.Web.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            try
            {
                int //productId = Int32.Parse(Session["ProductId"].ToString()),
                       userId = Int32.Parse(Session["UserId"].ToString());

                ViewBag.productId = Session["ProductId"];

                if (Session["UserType"].ToString() == "None" || Session["UserType"].ToString() == "TeamMember" || Session["UserType"].ToString() == "TeamLeader")
                {
                   

                    var taskRepo = new TaskRepository();
                    var assignedTasks = taskRepo.GetAssignedTasksForUser(userId);

                    if (assignedTasks != null)
                    {
                        var model = new DashboardModel();

                        model.AssignedTaskWorkModelCollection = new List<_AssignedTasksWorkModel>();

                        foreach (var task in assignedTasks)
                        {
                            model.AssignedTaskWorkModelCollection.Add(new _AssignedTasksWorkModel
                            {
                                TaskId = task.Id,
                                TaskName = task.Title,
                                WorkedHours = task.WorkLoads.Sum(y => (float?)y.Amount) ?? 0
                            });
                        }

                        return View(model);
                    }
                }
            }
            catch
            {
            }

            return View();
        }
	}
}