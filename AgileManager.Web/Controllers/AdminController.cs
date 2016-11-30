using AgileManager.Web.Utils;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileManager.Web.Controllers
{
    public class AdminController : Controller
    {
        
        //
        // GET: /Admin/SendInvite
        public ActionResult SendInvite()
        {
            //TODO: check credentials - throw error
            return View();
        }

        //
        // POST: /Admin/SendInvite
        [HttpPost]
        public ActionResult SendInvite(FormCollection collection)
        {
            //TODO: check credentials - throw error

            var email = collection.Get("email");
            var registrationRepo = new RegistrationDetailRepository();

            //TODO: check if invite wasn't already sent
            var regCode = registrationRepo.CreateEntry(email);

            var body = String.Format("{0} {1}{2}", EmailServerRepository.DefaultBody, EmailServerRepository.DefaultRegistrationLink, regCode);
            UtilMethods.SendEmail(email, EmailServerRepository.DefaultSubject, body);

            //TODO show success message

            return View();
        }
	}
}