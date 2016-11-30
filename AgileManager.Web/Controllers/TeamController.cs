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
    public class TeamController : Controller
    {
        protected TeamRepository _teamRepo;

        public TeamController() : base()
        {
            _teamRepo = new TeamRepository();
        }

        //
        // GET: /Team/
        public ActionResult Index()
        {
            var teams = _teamRepo.GetAll();

            return View(teams);
        }

        //
        // GET: /Team/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var team = _teamRepo.GetById(id); //_teamRepo.GetTeamByIdWithUsers(id);

                var productModel = new TeamModel()
                {
                    Team = team,
                    AutocompleteModel = new _AutocompleteModel()
                    {
                        UrlAdd = Url.Action("GetAssignUserToTeam", "Team", new { httproute = "" }),
                        UrlAutocomplete = Url.Action("GetAssignableUsersForTeam", "Team", new { httproute = "" }),
                        UrlDelete = Url.Action("PostUnassignUser", "Team", new { httproute = "" }),
                        ExistingItems = team.Members.Select(x => x.Email).ToList(),
                        AssignPanelHeader = "Assign an user",
                        AssigneesPanelHeader = "Assigned users"
                    }
                };

                return View(productModel);
            }
            catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }
        }

        //
        // GET: /Team/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Team/Create
        [HttpPost]
        public ActionResult Create(Team model)
        {
            try
            {
                if(_teamRepo.AddTeam(model))
                    return RedirectToAction("Index");

                // add failed
                ModelState.AddModelError(string.Empty, "Error: Duplicate team names, please choose another name!");
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Team/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _teamRepo.GetById(id);
            return View(model);
        }

        //
        // POST: /Team/Edit/5
        [HttpPost]
        public ActionResult Edit(Team model)
        {
            try
            {
                if (_teamRepo.EditTeam(model))
                    return RedirectToAction("Index");

                ModelState.AddModelError(string.Empty, "Error: Duplicate team names, please choose another name!");
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Team/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _teamRepo.DeleteTeam(id);
            }
            catch
            {
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Team/SetTeamLeader/5
        public ActionResult SetTeamLeader(int id)
        {
            var team = _teamRepo.GetTeamWithRelatedItems(id); 
            return View(team);
        }

        //
        // POST: /Team/SetTeamLeader/5
        [HttpPost]
        public ActionResult SetTeamLeader(int id, FormCollection collection)
        {
            try
            {
                int userId = Int32.Parse(collection["TeamLeader.Id"]);

                if(_teamRepo.SetTeamLeader(id, userId))
                    return RedirectToAction("Index");           
            }
            catch
            {                
            }

            return RedirectToAction("SetTeamLeader", id);
        }

    }
}
