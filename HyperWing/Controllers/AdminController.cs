using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HyperWing.BLL;
using HyperWing.Model;

namespace HyperWing.Controllers
{
    public class AdminController : Controller
    {
        private IAdminLogikk _adminBLL;

        public AdminController()
        {
            _adminBLL = new AdminLogikk();
        }
        public AdminController(IAdminLogikk stub)
        {
            _adminBLL = stub;
        }

        public ActionResult Login()
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

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin innLoggetAdmin)
        {
            if (.adminDB(innLoggetAdmin))
            {
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return RedirectToAction("AdminSide");
            }
            else
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }
        */
        public ActionResult ReiseListe()
        {
            List<Reiser> alleReiser = _adminBLL.hentAlleReiser();
            return View(alleReiser);
        }

        public ActionResult AdminSide()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                ViewBag.Innlogget = true;
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("Login");
        }


        public ActionResult VisAdminBestilling()
        {

            return View();

        }


        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            return RedirectToAction("Login");
        }

        public ActionResult ListeteKunder()
        {
            return View(_adminBLL.hentAlleKunder());
        }



    }
}