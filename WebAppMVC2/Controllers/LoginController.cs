using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using WebAppMVC2.Models;

namespace WebAppMVC2.Controllers
{
    public class LoginController : Controller
    {

        LindaEntities db = new LindaEntities();
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objchk)
        {
            if (ModelState.IsValid)
            {
                using (LindaEntities db = new LindaEntities())
                {
                    var obj = db.users.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["username"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");

                    }

                    else
                    {
                        ModelState.AddModelError("", "The username or password is incorrect");
                    }


                }
            }
            return View(objchk);
        }
    }
}
        