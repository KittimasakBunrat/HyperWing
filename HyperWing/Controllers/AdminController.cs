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

        public ActionResult RegistrerKunde()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerKunde(Kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                bool insertOK = _adminBLL.settInnKunde(innKunde);
                if (insertOK)
                {
                    return RedirectToAction("ListeKunder");
                }
            }
            return View();
        }

        public ActionResult RegistrerFlyplass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerFlyplass(Flyplasser innFlyplass)
        {
            if (ModelState.IsValid)
            {
                bool insertOK = _adminBLL.settInnFlyplass(innFlyplass);
                if (insertOK)
                {
                    return RedirectToAction("ListeFlyplasser");
                }
            }
            return View();
        }

        public ActionResult RegistrerBillett()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerBillett(Billett innBillett)
        {
            if (ModelState.IsValid)
            {
                bool insertOK = _adminBLL.settInnBillett(innBillett);
                if (insertOK)
                {
                    return RedirectToAction("ListeBilletter");
                }
            }
            return View();
        }

        public ActionResult RegistrerReise()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerReise(Reiser innReise)
        {
            if (ModelState.IsValid)
            {
                bool insertOK = _adminBLL.settInnReise(innReise);
                if (insertOK)
                {
                    return RedirectToAction("ListeReiser");
                }
            }
            return View();
        }

        public ActionResult EndreKunde(int id)
        {
            Kunde enKunde = _adminBLL.hentEnKunde(id);
            return View(enKunde);
        }

        [HttpPost]
        public ActionResult EndreKunde(int id, Kunde endreKunde)
        {
            bool endringOK = _adminBLL.endreKunde(id, endreKunde);
            if (endringOK)
            {
                return RedirectToAction("ListeKunder");
            }
            return View();
        }

        public ActionResult EndreFlyplass(int id)
        {
            Flyplasser enFlyplass = _adminBLL.hentEnFlyplass(id);
            return View(enFlyplass);
        }

        [HttpPost]
        public ActionResult EndreFlyplass(int id, Flyplasser endreFlyplass)
        {
            bool endringOK = _adminBLL.endreFlyplass(id, endreFlyplass);
            if (endringOK)
            {
                return RedirectToAction("ListeFlyplasser");
            }
            return View();
        }

        public ActionResult EndreBillett(int id)
        {
            Billett enBillett = _adminBLL.hentEnBillett(id);
            return View(enBillett);
        }

        [HttpPost]
        public ActionResult EndreBillett(int id, Billett endreBillett)
        {
            bool endringOK = _adminBLL.endreBillett(id, endreBillett);
            if (endringOK)
            {
                return RedirectToAction("ListeBilletter");
            }
            return View();
        }

        public ActionResult EndreReise(int id)
        {
            Reiser enReise = _adminBLL.hentEnReise(id);
            return View(enReise);
        }

        [HttpPost]
        public ActionResult EndreReise(int id, Reiser endreReise)
        {
            bool endringOK = _adminBLL.endreReise(id, endreReise);
            if (endringOK)
            {
                return RedirectToAction("ListeReiser");
            }
            return View();
        }
    }
}