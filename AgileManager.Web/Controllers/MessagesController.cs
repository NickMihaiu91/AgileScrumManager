using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileManager.Web.Controllers
{
    public class MessagesController : Controller
    {
        //
        // GET: /Messages/ResetPasswordEmailSent
        public ActionResult ResetPasswordEmailSent()
        {
            return View();
        }
	}
}