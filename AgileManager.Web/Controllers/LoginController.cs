using AgileManager.Web.Models;
using AgileManager.Web.Utils;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AgileManager.Web.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new UserRepository();
                var authUser = repo.CheckCredentials(model.Email, model.Password);

                if (authUser)
                {
                    var user = repo.GetUserByEmail(model.Email);
                    var productOnWhichUserWorks = repo.GetProductOnWhichUserWorks(user.Id);
                    int? productId = null;
                    int? backlogId = null;

                    if(productOnWhichUserWorks != null)
                    {
                        productId = productOnWhichUserWorks.Id;
                        backlogId = productOnWhichUserWorks.BacklogId;
                    }

                    if(user.UserType == DomainClasses.Enums.UserType.ProductOwner)
                    {
                        var productRepo = new ProductRepository();
                        var productForPO = productRepo.GetProductForProductOwner(user.Id);
                        productId = productForPO.Id;
                        backlogId = productForPO.BacklogId;
                    }

                    Session["UserId"] = user.Id;
                    FormsAuthentication.SetAuthCookie(model.Email, false);

                    Session["UserEmail"] = user.Email;
                    Session["UserType"] = user.UserType.ToString();
                    Session["ProductId"] = productId;
                    Session["BacklogId"] = backlogId;

                    return RedirectToAction("Index", "Dashboard");
                }
            }

            ModelState.AddModelError(String.Empty, "Incorrect email or password !");
            return View(model);
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(FormCollection collection)
        {
            string email = collection["email"];

            var userRepo = new UserRepository();

            var resetCode = userRepo.ResetPassword(collection["email"]);

            var emailBody = String.Format("{0} {1}{2}", "Link for reseting password in Agile Scrum Manager: ", "http://localhost:6250/User/ResetPassword/", resetCode);

            UtilMethods.SendEmail(email, "Agile Scrum Manager - Reset password", emailBody);

            return RedirectToAction("ResetPasswordEmailSent", "Messages");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();

            //FormsAuthentication.RedirectToLoginPage();

            return RedirectToAction("Index");
        }

	}
}