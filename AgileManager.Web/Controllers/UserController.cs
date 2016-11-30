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
    public class UserController : Controller
    {
        protected UserRepository userRepo;

        public UserController() : base()
        {
            userRepo = new UserRepository();
        }

        //
        // GET: /User/
        public ActionResult Index()
        {
            return View(userRepo.GetAll());
        }

        //
        // GET: /User/Profile/5
        public new ActionResult Profile(int id)
        {
            return View(userRepo.GetUserByIdWithRelatedItems(id));
        }

        //
        // GET: /User/Create/eadd2f20cf91498d901085254868e687
        public ActionResult Create(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
                return Content("Invalid registration code !");

            var repo = new RegistrationDetailRepository();

            if (!repo.ValidateRegistrationCode(id))
                return Content("Invalid registration code !");

            var regDetail = repo.GetEntry(id);

            var model = new UserRegistrationModel { Email = regDetail.Email };

            return View(model);
        }

        //
        // POST: /User/Create/eadd2f20cf91498d901085254868e687
        [HttpPost]
        public ActionResult Create(string id, UserRegistrationModel model)
        {
            try
            {
                var repo = new RegistrationDetailRepository();
                var regDetail = repo.GetEntry(id);

                // check same email wasn't used before
                if (userRepo.CheckUserExists(regDetail.Email))
                    return Content("E-mail address already used for user registration !");

                if (model.Password != model.ConfirmationPassword)
                {
                    ModelState.AddModelError(String.Empty, "Non-matching passwords !");
                    return View(model);
                }

                // create user
                var user = new User
                {
                    Email = regDetail.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Password = model.Password
                };

                userRepo.CreateUser(ref user, id);

                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            return View();
        }

        //
        // GET: /User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(userRepo.GetById(id));
        }

        //
        // POST: /User/Edit/5
        [HttpPost]
        public ActionResult Edit(User model)
        {
            try
            {
                userRepo.EditUser(model);

                return RedirectToAction("Profile", new { id = model.Id });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5
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
        // GET: /User/ChangePassword/5
        public ActionResult ChangePassword(int id)
        {
            return View(new ChangePasswordModel());
        }

        //
        // POST: /User/ChangePassword/5
        [HttpPost]
        public ActionResult ChangePassword(int id, ChangePasswordModel model)
        {
            if (model.NewPassword != model.ConfirmationPassword)
            {
                ModelState.AddModelError(String.Empty, "Non-matching passwords !");
                return View(model);
            }

            if(!userRepo.ChangePassword(id, model.OldPassword, model.NewPassword))
            {
                ModelState.AddModelError(String.Empty, "Non-matching passwords !");
                return View(model);
            }

            return RedirectToAction("Profile", new { id = id });
        }

    }
}
