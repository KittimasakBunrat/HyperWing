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

       // BLL.AdminLogikk bll = new BLL.AdminLogikk();

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
            if (_adminBLL.adminDB(innLoggetAdmin))
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
            List<Kunde> alleKunder = _adminBLL.hentAlleKunder();
            return View(alleKunder);
        }

        public ActionResult ListeFlyplasser()
        {
            List<Flyplasser> alleFlyplasser = _adminBLL.hentAlleFlyplasser();
            return View(alleFlyplasser);
        }

        public ActionResult ListeBilletter()
        {
            List<Billett> alleBilletter = _adminBLL.hentAlleBilletter();
            return View(alleBilletter);
        }

        public ActionResult ListeReiser()
        {
            List<Reiser> alleReiser = _adminBLL.hentAlleReiser();
            return View(alleReiser);
        }



    }
}