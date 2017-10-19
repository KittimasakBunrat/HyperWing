using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Text;
using System.Security.Cryptography;
using HyperWingAdmin.Models;

namespace HyperWingAdmin.Controllers
{
    public class SikkerhetsController : Controller
    {
        // GET: Sikkerhets
        public ActionResult Index()
        {
            if(Session["LoggatIn"] == null)
            {
                Session["LoggatIn"] = false;
                ViewBag.Inloggad = false;
            }
            else
            {
                ViewBag.Inloggad = (bool)Session["LoggatIn"];
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(admin inLoggad)
        {
            if (admin_i_db(inLoggad))
            {
                Session["LoggetInn"] = true;
                ViewBag.Innloggad = true;
                return View();
            }
            else
            {
                Session["LoggetInn"] = false;
                ViewBag.Innloggad = false;
                return View();
            }
        }

        private static byte[] lagHash(string innPassord, byte[] innSalt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(innPassord, innSalt, 1000); // 1000 angir hvor mange ganger hash funskjonen skal utføres for økt sikkerhet
            return pbkdf2.GetBytes(keyLength);
        }

        private static byte[] lagSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }

        private static bool admin_i_db(admin innAdmin)
        {
            using (var db = new AdminContext())
            {
                dbAdmin funnetAdmin = db.Admins.FirstOrDefault(b => b.Brukernavn == innAdmin.Brukernavn);
                if(funnetAdmin != null)
                {
                    byte[] passordForTest = lagHash(innAdmin.Passord, funnetAdmin.Salt);
                    bool riktigAdmin = funnetAdmin.Passord.SequenceEqual(passordForTest);
                    return riktigAdmin;
                }
                else
                {
                    return false;
                }
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
    }
}