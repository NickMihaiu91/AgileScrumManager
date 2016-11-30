using AgileManager.Web.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileManager.Web.Controllers
{
    public class SearchController : Controller
    {

        //
        // GET: /Search/TaskSearch
        public ActionResult TaskSearch()
        {
            var model = new TaskSearchModel
            {
                Results = new List<DomainClasses.Task>(),
                DisplayNoResultsMessage = false,
                SearchModel = new QueryModel()
            };
            return View(model);
        }

        //
        // POST: /Search/TaskSearch
        [HttpPost]
        public ActionResult TaskSearch(TaskSearchModel model)
        {
            try
            {
                int backlogId = Int32.Parse(Session["BacklogId"].ToString());

                var taskRepo = new TaskRepository();
                var results = taskRepo.QueryTasks(backlogId, model.SearchModel.Title, model.SearchModel.TaskPriority, model.SearchModel.TaskStatus, model.SearchModel.TaskType);

                var returnModel = new TaskSearchModel()
                {
                    DisplayNoResultsMessage =  results.Count < 1,
                    SearchModel = model.SearchModel,
                    Results = results
                };

                return View(returnModel);
            }
            catch
            {
                return View();
            }
        }
   
    }
}
