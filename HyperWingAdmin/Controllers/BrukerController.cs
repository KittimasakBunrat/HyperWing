using HyperWingAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HyperWingAdmin.Controllers
{
    public class BrukerController : Controller
    {
        // GET: Bruker
        public ActionResult Index()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.innLogget = false;
            }
            else {
                ViewBag.innLogget = (bool)Session["LoggetInn"];
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Bruker b) {
            if (sjekkDB(b))
            {
                Session["LoggetInn"] = true;
                ViewBag.innLogget = true;
                return View();
            }
            else {
                Session["LoggetInn"] = false;
                ViewBag.innLogget = false;
                return View();
            }

        }

        public ActionResult InnloggetSide()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            return RedirectToAction("index");
        }

        private static byte[] Hash(String s) {
            byte[] inn, ut;
            var alg = SHA256.Create();
            inn = Encoding.UTF8.GetBytes(s);
            ut = alg.ComputeHash(inn);
            return ut;
        }

        private static string Salt() {
            byte[] temp = new byte[10];
            string tempString;

            var rngCrypto = new RNGCryptoServiceProvider();
            rngCrypto.GetBytes(temp);
            tempString = Convert.ToBase64String(temp);
            return tempString;
        }

        private static bool sjekkDB(Bruker sjekkBruker) {
            using (var db = new BrukerContext()) {
                dbBruker matchetBruker = db.Brukere.FirstOrDefault(b => b.Brukernavn == sjekkBruker.Brukernavn);

                if (matchetBruker != null)
                {
                    byte[] pass = Hash(sjekkBruker.Passord + matchetBruker.Salt);
                    bool riktigBruker = matchetBruker.Passord.SequenceEqual(pass);
                    return riktigBruker;
                }
                else {
                    return false;
                }
            }
        }


    }
}