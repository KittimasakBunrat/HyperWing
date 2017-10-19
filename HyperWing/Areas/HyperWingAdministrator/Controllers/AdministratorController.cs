using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HyperWing.Model;
using HyperWing.BLL;

namespace HyperWingAdministrator.Controllers
{
    public class AdministratorController : Controller
    {
        public ActionResult Index()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Admin innLoggetAdmin)
        {
            if (AdminLogikk.adminDB(innLoggetAdmin))
            {
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return View();
            }
            else
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }



        public ActionResult Innlogget()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }

            return RedirectToAction("Login");
        }

        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            return RedirectToAction("Login");
        }



    }
}