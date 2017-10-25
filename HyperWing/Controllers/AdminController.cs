using HyperWing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HyperWing.Controllers
{
    public class AdminController : Controller
    {
        HyperWing.BLL.AdminBLL bll = new HyperWing.BLL.AdminBLL();

        public ActionResult Login()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin innLoggetAdmin)
        {
            if (bll.adminDB(innLoggetAdmin))
            {
                Session["LoggetInn"] = true;
                return RedirectToAction("AdminSide");
            }
            else
            {
                Session["LoggetInn"] = false;
                return View();
            }
        }

        public ActionResult AdminSide()
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

        public ActionResult ListeKunder()
        {
            return View(bll.hentKunder());
        }

        public ActionResult ListeFlyplasser()
        {
            return View(bll.hentFlyplasser());
        }

        public ActionResult ListeBilletter()
        {
            return View(bll.hentBilletter());
        }

        public ActionResult ListeReiser()
        {
            return View(bll.hentReiser());
        }
    }
}