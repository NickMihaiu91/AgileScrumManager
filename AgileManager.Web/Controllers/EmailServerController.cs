using AgileManager.Web.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileManager.Web.Controllers
{
    public class EmailServerController : Controller
    {
        //
        // GET: /EmailServer/Add
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new EmailServerRepository();
                repo.SetEmailServer(model.Email, model.Password);

                return RedirectToAction("Index", "Dashboard");   
            }

            ModelState.AddModelError(String.Empty, "Incorrect email or password !");
            return View(model);
        }
	}
}